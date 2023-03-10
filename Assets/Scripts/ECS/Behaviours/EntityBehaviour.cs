using System;
using UnityEngine;
using Entitas.VisualDebugging.Unity;
using Core.ECS.ViewListeners;

namespace Core.ECS.Behaviours
{
    public abstract class EntityBehaviour : MonoBehaviour, IDisposable
    {
        protected GameContext Game => ECSExtensions.Game();
        public GameEntity Entity { get; private set; }

        protected virtual void Awake()
        {
            Entity = Game.CreateEntity();

            var controller = GetComponent<ViewController>() ?? gameObject.AddComponent<ViewController>();
            controller.InitializeView(Game, Entity);

            foreach (var listener in GetComponents<IEventListener>())
            {
                listener.RegisterListeners(Entity);
            }
        }
        public virtual void Dispose() => gameObject.DestroyGameObject();
    }
}