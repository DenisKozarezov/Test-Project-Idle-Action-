using UnityEngine;

namespace Core.ECS.Behaviours
{
    public sealed class DestinationRing : CollisionEntityBehaviour
    {
        protected override void OnTriggerEnter(Collider other) => OnPlayerBroughtStacks(other);

        private void OnPlayerBroughtStacks(Collider other)
        {
            if (TriggerBy(other, out GameEntity entered))
            {
                entered.isBroughtStacks = true;
            }
        }
    }
}