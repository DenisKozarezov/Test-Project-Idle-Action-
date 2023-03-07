using UnityEngine;
using Entitas;
using Core.Units;

namespace Core.ECS.ViewListeners
{
    public sealed class MovingListener : MonoBehaviour, IEventListener, IMovingListener, IStoppedMovingListener
    {
        private GameEntity _entity;
        private UnitAnimator _animator;

        private Vector3 _currentVelocity;
       // private float _currentVelocity;

        public void RegisterListeners(IEntity entity)
        {
            _entity = (GameEntity)entity;
            _entity.AddMovingListener(this);
            _entity.AddStoppedMovingListener(this);

            _animator = GetComponent<UnitAnimator>();
        }
        public void UnregisterListeners()
        {
            _entity.RemoveMovingListener();
            _entity.RemoveStoppedMovingListener();
        }
        public void OnMoving(GameEntity entity)
        {
            _currentVelocity = Vector3.SmoothDamp(_currentVelocity, entity.direction.Value, ref _currentVelocity, 0.2f);
            _animator.PlayRun(new Vector2(_currentVelocity.x, _currentVelocity.y));
        }
        public void OnStoppedMoving(GameEntity entity) => _animator.PlayIdle();
    }
}