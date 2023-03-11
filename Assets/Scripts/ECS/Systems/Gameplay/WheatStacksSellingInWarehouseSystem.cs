using System.Collections.Generic;
using UnityEngine;
using Entitas;
using DG.Tweening;

namespace Core.ECS.Systems
{
    public sealed class WheatStacksSellingInWarehouseSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _stacks;
        private readonly IGroup<GameEntity> _collectingPoints;
        private readonly IWheatStacksFactory _factory;
        public WheatStacksSellingInWarehouseSystem(GameContext game, IWheatStacksFactory factory) : base(game)
        {
            _stacks = game.GetGroup(GameMatcher.AllOf(GameMatcher.WheatStack, GameMatcher.Collected, GameMatcher.Grabbed));
            _collectingPoints = game.GetGroup(GameMatcher.CollectingPoint);
            _factory = factory;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.BroughtStacks.Added());
        }
        protected override bool Filter(GameEntity entity)
        {
            return true;
        }
        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                foreach (GameEntity point in _collectingPoints)
                {
                    foreach (GameEntity stack in _stacks.GetEntities())
                    {
                        Vector3 collectingPoint = point.collectingPoint.Value.position;
                        stack.transform.Value
                            .DOMove(collectingPoint, 0.5f)
                            .SetEase(Ease.InOutBounce)
                            .SetLink(stack.transform.Value.gameObject)
                            .OnComplete(() => _factory.Despawn(stack));
                    }
                }
            }
        }
    }
}
