using UnityEngine;

namespace Core.Models
{
    [CreateAssetMenu(menuName = "Configuration/Units/Player")]
    public class PlayerModel : BaseModel
    {
        [field: Header("Characteristics")]
        [field: SerializeField] public byte MaxWheatStacks { get; private set; }
        [field: SerializeField, Min(0f)] public float MovementSpeed { get; private set; }
    }
}