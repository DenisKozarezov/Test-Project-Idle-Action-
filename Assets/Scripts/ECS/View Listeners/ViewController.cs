using System;
using UnityEngine;
using Entitas;
using Core.ECS.ViewComponentRegistrators;

namespace Core.ECS.ViewListeners
{
    public sealed class ViewController : MonoBehaviour, IViewController, IDisposable
    {
        private GameContext _game;
        public GameEntity Entity { get; private set; }

        public IViewController InitializeView(GameContext game, IEntity entity)
        {
            _game = game;
            Entity = (GameEntity)entity;
            Entity.AddViewController(this);
            Entity.AddId(_game.identifiers.Value.Next());

            AddDestroyedListener();
            RegisterViewComponents();

            return this;
        }

        private void Start()
        {
            RegisterCollisions();
        }
        private void RegisterViewComponents()
        {
            foreach (var registrator in GetComponents<IViewComponentRegistrator>())
            {
                registrator.Register(Entity);
            }

            var spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null) Entity.AddSpriteRenderer(spriteRenderer);
        }
        private void UnregisterListeners()
        {
            foreach (IEventListener listener in GetComponents<IEventListener>())
                listener.UnregisterListeners();
        }
        private void AddDestroyedListener()
        {
            if (!GetComponent<DestroyedListener>())
                gameObject.AddComponent<DestroyedListener>();
        }

        private void RegisterCollisions()
        {
            foreach (Collider collider in GetComponentsInChildren<Collider>(includeInactive: true))
            {
                _game.collisionRegistry.Value.Register(collider.GetInstanceID(), this);
            }
        }
        private void UnregisterCollisions()
        {
            foreach (Collider collider in GetComponentsInChildren<Collider>())
                _game.collisionRegistry.Value.Unregister(collider.GetInstanceID());
        }
        public void Dispose()
        {
            UnregisterCollisions();
            UnregisterListeners();
        }
    }
}