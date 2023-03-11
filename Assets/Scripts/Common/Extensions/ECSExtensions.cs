using UnityEngine;

namespace Core
{
    public static class ECSExtensions
    {
        public static GameContext Game() => Contexts.sharedInstance.game;
        public static InputContext Input() => Contexts.sharedInstance.input;
        public static GameEntity Empty() => Game().CreateEntity();
        public static bool IsNullOrEmpty(this GameEntity entity) => !entity.isEnabled || entity.isDestroyed;
        public static bool Matches(this Collider collider, LayerMask layerMask) =>
        ((1 << collider.gameObject.layer) & layerMask) != 0;
    }
}