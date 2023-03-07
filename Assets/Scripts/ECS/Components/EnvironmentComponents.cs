using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.EventTarget;
using static Entitas.CodeGeneration.Attributes.CleanupMode;

namespace Core.ECS.Components
{
    public sealed class Vegetation : IComponent { }
    public sealed class CanBeCut : IComponent { }
    public sealed class IsGrowing : IComponent { public float Duration; }
    public sealed class RegenerationTime : IComponent { public float Value; }
}
