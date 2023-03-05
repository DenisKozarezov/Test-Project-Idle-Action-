using UnityEngine;

namespace Core.ECS.ViewComponentRegistrators
{
    public sealed class ColliderComponentRegistrator : MonoBehaviour, IViewComponentRegistrator
    {
        [SerializeField]
        private Collider _collider;

        public void Register(GameEntity entity) => entity.AddCollider(_collider);
    }
}