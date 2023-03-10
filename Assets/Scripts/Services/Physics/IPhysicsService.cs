using System.Collections.Generic;
using UnityEngine;

namespace Core.Services
{
    public interface IPhysicsService
    {
        IEnumerable<GameEntity> RaycastThroughScreenPoint(Vector3 position, int layerMask);
        IEnumerable<GameEntity> RaycastCircle(Vector3 position, float radius, int layerMask);
    }
}