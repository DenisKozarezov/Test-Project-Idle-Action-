using UnityEngine;

namespace Core.Models
{
    [CreateAssetMenu(menuName = "Configuration/Game Config")]
    public sealed class GameConfig : ScriptableObject
    {
        [field: Header("Environment")]
        [field: SerializeField, Min(0f)] public float RegenerationTime { get; private set; }
        [field: SerializeField] public byte MaxWheatStacks { get; private set; }
        [field: SerializeField] public byte WheatStacksPoolCapacity { get; private set; }
        [field: SerializeField] public byte WheatStackPrice { get; private set; }
        [field: SerializeField] public GameObject WheatStackPrefab { get; private set; }

        [field: Header("Player")]
        [field: SerializeField, Min(0f)] public float MovementSpeed { get; private set; }

        [field: Header("UI")]
        [field: SerializeField] public Sprite CoinPrefab { get; private set; }
    }
}