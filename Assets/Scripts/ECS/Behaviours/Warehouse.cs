using UnityEngine;

namespace Core.ECS.Behaviours
{
    public sealed class Warehouse : EntityBehaviour
    {
        [SerializeField]
        private Transform _collectingPoint;

        private void Start()
        {
            Entity.AddCollectingPoint(_collectingPoint);
            Entity.AddPosition(transform.position);
        }
    }
}