using UnityEngine;
using Core.Models;

namespace Core.ECS.Behaviours
{
    public sealed class VegetationBehaviour : CollisionEntityBehaviour
    {
        [SerializeReference]
        private GameConfig _config;

        private void Start()
        {
            Entity.isVegetation = true;
            Entity.isCanBeSliced = true;
            Entity.AddRegenerationTime(_config.RegenerationTime);
            Entity.AddTransform(transform);
            Entity.AddPosition(transform.position);
        }
    }
}