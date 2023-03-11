using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using static Entitas.CodeGeneration.Attributes.EventTarget;
using static Entitas.CodeGeneration.Attributes.CleanupMode;

namespace Core.ECS.Components
{
    public sealed class Vegetation : IComponent { }
    public sealed class CanBeSliced : IComponent { }
    public sealed class IsGrowing : IComponent { public float Duration; }
    public sealed class RegenerationTime : IComponent { public float Value; }
    public sealed class CollectingPoint : IComponent { public Transform Value; }

    public sealed class WheatStack : IComponent { public byte Price; }
    public sealed class Grabbed : IComponent { }
    [Event(Self)] public sealed class Collected : IComponent { }
    [Event(Any), Cleanup(RemoveComponent)] public sealed class StackObtained : IComponent { }
}
