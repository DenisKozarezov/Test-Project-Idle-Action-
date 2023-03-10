using UnityEngine;
using Entitas;

namespace Core.ECS.ViewListeners
{
    public sealed class PositionListener : MonoBehaviour, IEventListener, IPositionListener, IStoppedMovingListener
    {
        private GameEntity _entity;
        private Rigidbody _rigidbody;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        public void RegisterListeners(IEntity entity)
        {
            _entity = (GameEntity)entity;
            _entity.AddPositionListener(this);
            _entity.AddStoppedMovingListener(this);
        }
        public void UnregisterListeners()
        {
            _entity.RemovePositionListener(this);
            _entity.RemoveStoppedMovingListener(this);
        }
        public void OnPosition(GameEntity entity, Vector3 value)
        {
            Vector3 velocity = value - transform.position;

            if (_rigidbody == null || velocity == Vector3.zero)
                transform.position = value;
            else
                _rigidbody.MovePosition(value);  
        }
        public void OnStoppedMoving(GameEntity entity)
        {
            if (_rigidbody != null)
            {
                _rigidbody.velocity = _rigidbody.velocity.SetX(0f).SetZ(0f);
            }
        }
    }
}