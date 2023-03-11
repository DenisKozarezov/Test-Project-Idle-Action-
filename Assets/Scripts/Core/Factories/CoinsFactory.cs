using UnityEngine;
using Zenject;

namespace Core
{
    public interface ICoinsFactory : IMemoryPool<Vector2, RectTransform> { }

    public sealed class CoinsFactory : MemoryPool<Vector2, RectTransform>, ICoinsFactory 
    {
        protected override void OnCreated(RectTransform item)
        {
            base.OnCreated(item);
            item.gameObject.SetActive(false);
        }
        protected override void OnDespawned(RectTransform item)
        {
            base.OnDespawned(item);
            item.gameObject.SetActive(false);
        }
        protected override void Reinitialize(Vector2 position, RectTransform item)
        {
            base.Reinitialize(position, item);
            item.position = position;
            item.gameObject.SetActive(true);
        }
    }
}
