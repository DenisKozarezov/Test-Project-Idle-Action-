using System;
using UnityEngine;
using Entitas;

namespace Core.ECS.ViewListeners
{
    public sealed class TouchClickListener : MonoBehaviour, IEventListener, IAnyTouchClickListener
    {
        private GameEntity _entity;
        public void RegisterListeners(IEntity entity)
        {
            _entity = (GameEntity)entity;
        }
        public void UnregisterListeners()
        {
            throw new NotImplementedException();
        }
        public void OnAnyTouchClick(InputEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
