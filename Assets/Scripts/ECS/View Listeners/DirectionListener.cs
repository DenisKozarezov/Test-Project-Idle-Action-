using UnityEngine;
using Entitas;

namespace Core.ECS.ViewListeners
{
    public sealed class DirectionListener : MonoBehaviour, IEventListener, IDirectionListener
    {
        private GameEntity _entity;

        public void RegisterListeners(IEntity entity)
        {
            _entity = (GameEntity)entity;
            _entity.AddDirectionListener(this);
        }
        public void UnregisterListeners()
        {
            _entity.RemoveDirection();
        }
        public void OnDirection(GameEntity entity, Vector3 value)
        {
            transform.rotation = Quaternion.LookRotation(value, Vector3.up);
        }
    }
}