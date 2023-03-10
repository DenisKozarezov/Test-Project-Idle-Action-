using System;
using UnityEngine;
using Zenject;
using Core.Models;

namespace Core.ECS.Behaviours
{
    public sealed class WheatStackBehaviour : CollisionEntityBehaviour, IPoolable<Vector3, IMemoryPool>, IDisposable
    {
        [SerializeReference]
        private GameConfig _config;

        private IMemoryPool _pool;

        protected override void Awake() { }
        public override void Dispose() { }
        public void OnDespawned()
        {
            _pool = null;
        }
        public void OnSpawned(Vector3 position, IMemoryPool pool)
        {
            base.Awake();
            _pool = pool;
            transform.position = position;
            gameObject.layer = Constants.VegetationLayer;
            Entity.rigidbody.Value.useGravity = true;
            Entity.rigidbody.Value.constraints = RigidbodyConstraints.FreezeRotation;
            Entity.AddWheatStack(_config.WheatStackPrice);
            Entity.AddTransform(transform);
            Entity.AddPosition(transform.position);
        }

        public class Factory : PlaceholderFactory<Vector3, WheatStackBehaviour> { }
    }
}