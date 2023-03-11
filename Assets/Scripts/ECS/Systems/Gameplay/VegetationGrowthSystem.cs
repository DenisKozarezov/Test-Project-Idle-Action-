using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Entitas;

namespace Core.ECS.Systems
{
    public sealed class VegetationGrowthSystem : ReactiveSystem<GameEntity>
    {
        public VegetationGrowthSystem(GameContext game) : base(game)
        {
            
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CanBeSliced.Removed());
        }
        protected override bool Filter(GameEntity entity)
        {
            return entity.isVegetation && entity.hasIsGrowing;
        }
        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                Vector3 position = entity.position.Value;
                float regenerationTime = entity.regenerationTime.Value;

                DOTween.To(() => position + Vector3.down * 3f, (x) => entity.ReplacePosition(x), position, regenerationTime)
                    .SetEase(Ease.Linear)
                    .SetLink(entity.transform.Value.gameObject)
                    .OnComplete(() =>
                    {
                        entity.isCanBeSliced = true;
                        entity.RemoveIsGrowing();
                    });
            }
        } 
    }
}
