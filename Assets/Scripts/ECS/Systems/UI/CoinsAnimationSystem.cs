using UnityEngine;
using System.Collections.Generic;
using Entitas;
using DG.Tweening;

namespace Core.ECS.Systems
{
    public sealed class CoinsAnimationSystem : ReactiveSystem<GameEntity>
    {
        private readonly ICoinsFactory _factory;
        private readonly IGroup<GameEntity> _collectingPoints;
        private readonly IGroup<GameEntity> _moneyCounter;
        private readonly Camera _camera;

        private bool _isVibrating;

        public CoinsAnimationSystem(GameContext game, ICoinsFactory factory) : base(game)
        {
            _factory = factory;
            _collectingPoints = game.GetGroup(GameMatcher.CollectingPoint);
            _moneyCounter = game.GetGroup(GameMatcher.MoneyCounter);
            _camera = Camera.main;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Sold.Added());
        }
        protected override bool Filter(GameEntity entity)
        {
            return entity.hasWheatStack;
        }
        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity point in _collectingPoints)
            {
                foreach (GameEntity counter in _moneyCounter)
                {
                    int index = 0;
                    foreach (GameEntity entity in entities)
                    {
                        Vector2 screenPos = _camera.WorldToScreenPoint(point.position.Value);
                        RectTransform coin = _factory.Spawn(screenPos);

                        StartAnimation(coin, counter.transform.Value, index, entities.Count);
                        index++;
                    }
                }
            }
        }

        private void StartAnimation(RectTransform coin, Transform counter, int index, int count)
        {
            float delay = 0.5f * ((float)index / count);

            Sequence sequence = DOTween.Sequence();
            sequence.SetLink(coin.gameObject);
            sequence.PrependInterval(delay);
            sequence.Append(coin.transform
                .DOMove(counter.position, duration: 0.3f)
                .SetEase(Ease.Linear)
                .OnComplete(() => _factory.Despawn(coin)));

            if (!_isVibrating)
            {
                _isVibrating = true;
                sequence.Append(counter
                    .DOPunchPosition(Vector2.up * 1.5f, duration: 1.5f, vibrato: 10)
                    .OnComplete(() => _isVibrating = false));
            }
        }
    }
}
