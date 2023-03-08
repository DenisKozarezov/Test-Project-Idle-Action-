using UnityEngine;
using Core.Models;

namespace Core.ECS.Behaviours
{
    public sealed class PlayerBehaviour : EntityBehaviour
    {
        [SerializeField]
        private GameConfig _config;

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
        }
    }
}