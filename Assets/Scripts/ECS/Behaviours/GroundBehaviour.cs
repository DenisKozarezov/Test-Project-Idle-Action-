using UnityEngine;

namespace Core.ECS.Behaviours
{
    public sealed class GroundBehaviour : CollisionEntityBehaviour
    {
        protected override void OnCollisionEnter(Collision other) => MarkGrounded(other.collider);
        protected override void OnCollisionExit(Collision other) => UnmarkGrounded(other.collider);

        private void MarkGrounded(Collider collider)
        {
            if (TriggerBy(collider, out GameEntity entered))
            {
                entered.isGrounded = true;
            }
        }
        private void UnmarkGrounded(Collider collider)
        {
            if (ResetTriggerBy(collider, out GameEntity exit))
            {
                exit.isGrounded = false;
            }
        }
    }
}