using UnityEngine;

namespace Core.ECS.Behaviours
{
    [RequireComponent(typeof(Collider))]
    public class CollisionEntityBehaviour : EntityBehaviour
    {
        [SerializeField]
        protected LayerMask _triggeringLayers;

        protected virtual void OnTriggerEnter(Collider other)
            => TriggerBy(other, out GameEntity _);
        protected virtual void OnTriggerExit(Collider other)
            => ResetTriggerBy(other, out GameEntity _);
        protected virtual void OnCollisionEnter(Collision other)
            => TriggerBy(other.collider, out GameEntity _);
        protected virtual void OnCollisionExit(Collision other)
            => ResetTriggerBy(other.collider, out GameEntity _);

        protected bool TriggerBy(Collider collision, out GameEntity entered)
        {
            if (collision.Matches(_triggeringLayers))
            {
                entered = Game
                  .collisionRegistry.Value
                  .Take(collision.GetInstanceID())
                  .Entity;

                Entity?.ReplaceCollided(entered.id.Value);
                entered?.ReplaceCollided(Entity.id.Value);
                return true;
            }
            entered = null;
            return false;
        }
        protected bool ResetTriggerBy(Collider collision, out GameEntity exit)
        {
            exit = null;

            if (collision.Matches(_triggeringLayers))
            {
                exit = Game
                  .collisionRegistry.Value
                  .Take(collision.GetInstanceID())
                  .Entity;

                Entity.With(x => x.RemoveCollided(), Entity.hasCollided);
                exit.With(x => x.RemoveCollided(), exit.hasCollided);
                return true;
            }
            return false;
        }
    }
}