using System.Collections.Generic;
using Entitas;
using Core.ECS.Behaviours;

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
                
            }
        } 
    }
}
