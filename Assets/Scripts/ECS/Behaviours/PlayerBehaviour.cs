using UnityEngine;
using Core.Models;

namespace Core.ECS.Behaviours
{
    public sealed class PlayerBehaviour : EntityBehaviour
    {
        [SerializeField]
        private PlayerModel _playerModel;

        private void Start()
        {
            Entity.isPlayer = true;
            Entity.AddTransform(transform);
            Entity.AddPosition(transform.position);
        }
    }
}