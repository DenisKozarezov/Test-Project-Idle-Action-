using System.Collections.Generic;
using UnityEngine;
using Core.ECS.ViewListeners;

namespace Core.Services
{
    public sealed class UnityPhysicsService : IPhysicsService
    {
        private static readonly RaycastHit[] Hits = new RaycastHit[20];

        private IViewController TakeViewController(int instanceId)
        {
            IViewController viewController =
                ECSExtensions.Game()
                .collisionRegistry.Value
                .Take(instanceId);
            return viewController;
        }
        private int Raycast(Vector3 worldPos, RaycastHit[] hits, int layerMask) =>
          Physics.RaycastNonAlloc(worldPos, worldPos, hits, layerMask);
        public int Overlap(Vector3 worldPos, float radius, RaycastHit[] hits, int layerMask) =>
          Physics.SphereCastNonAlloc(worldPos, radius, Vector3.up, hits, layerMask);

        public IEnumerable<GameEntity> RaycastThroughScreenPoint(Vector3 position, int layerMask)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(position);
            int hitCount = Raycast(worldPos, Hits, layerMask);

            for (int i = 0; i < hitCount; i++)
            {
                RaycastHit hit = Hits[i];
                if (hit.collider == null) continue;

                IViewController controller = TakeViewController(hit.collider.GetInstanceID());
                if (controller == null) continue;

                yield return controller.Entity;
            }
        }
        public IEnumerable<GameEntity> RaycastCircle(Vector3 position, float radius, int layerMask)
        {
            int hitCount = Overlap(position, radius, Hits, layerMask);

            for (int i = 0; i < hitCount; i++)
            {
                IViewController controller = TakeViewController(Hits[i].collider.GetInstanceID());
                if (controller == null) continue;

                yield return controller.Entity;
            }
        }
    }
}