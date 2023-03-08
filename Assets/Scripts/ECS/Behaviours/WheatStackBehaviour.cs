using System;
using UnityEngine;
using Core.Models;
using Zenject;

namespace Core.ECS.Behaviours
{
    public sealed class WheatStackBehaviour : CollisionEntityBehaviour, IPoolable<Vector3, IMemoryPool>, IDisposable
    {
        [SerializeReference]
        private GameConfig _config;

        private IMemoryPool _pool;

        private void Start()
        {
            Entity.isVegetation = true;
            Entity.AddWheatStack(_config.WheatStackPrice);
            Entity.AddRegenerationTime(_config.RegenerationTime);
            Entity.AddTransform(transform);
            Entity.AddPosition(transform.position);
        }

        public void OnDespawned()
        {
            _pool = null;
        }
        public void OnSpawned(Vector3 position, IMemoryPool pool)
        {
            transform.position = position;
            _pool = pool;
        }
        public override void Dispose() => _pool?.Despawn(this);


        public class Factory : PlaceholderFactory<Vector3, WheatStackBehaviour> { }
    }
}