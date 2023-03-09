using UnityEngine;
using Core.Models;

namespace Core.ECS.Behaviours
{
    public sealed class PlayerBehaviour : EntityBehaviour
    {
        [SerializeReference]
        private GameConfig _config;
        [SerializeReference]
        private Transform _grabPoint;

        private void Start()
        {
            Entity.isPlayer = true;
            Entity.AddAnimator(GetComponent<Animator>());
            Entity.AddTransform(transform);
            Entity.AddPosition(transform.position);
            Entity.AddDirection(transform.forward);
            Entity.AddMovable(_config.MovementSpeed);
            Entity.AddCurrentWheatStacks(0);
            Entity.AddMaxWheatStacks(_config.MaxWheatStacks);
            Entity.AddGrabPoint(_grabPoint);
            Entity.AddPotentialMoney(0);
            Entity.AddCurrentMoney(0);
        }
    }
}