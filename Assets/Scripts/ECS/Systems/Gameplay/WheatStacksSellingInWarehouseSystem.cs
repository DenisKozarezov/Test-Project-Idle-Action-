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
            _stacks = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.WheatStack, GameMatcher.Collected, GameMatcher.Grabbed)
                .NoneOf(GameMatcher.Destroyed));
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
                    int index = 0;
                    foreach (GameEntity stack in _stacks)
                    {
                        Vector3 collectingPoint = point.collectingPoint.Value.position;
                        StartAnimation(stack, collectingPoint, index, _stacks.count);
                        index++;
                    }
                }
            }
        }

        private void StartAnimation(GameEntity stack, Vector3 collectingPoint, int index, int count)
        {
            Transform transform = stack.transform.Value;
            float delay = 0.5f * ((float)index / count);

            transform
                .DOMove(collectingPoint, duration: 0.3f)
                .SetDelay(delay)
                .SetEase(Ease.InOutBounce)
                .SetLink(transform.gameObject)
                .OnComplete(() =>
                {
                    stack.isSold = true;
                    _factory.Despawn(stack);
                });
        }
    }
}
