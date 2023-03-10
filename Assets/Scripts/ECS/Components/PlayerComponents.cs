using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.EventTarget;
using static Entitas.CodeGeneration.Attributes.CleanupMode;

namespace Core.ECS.Components
{
    // Tags
    public sealed class Player : IComponent { }

    public sealed class CurrentWheatStacks : IComponent { public byte Value; }
    public sealed class MaxWheatStacks : IComponent { public byte Value; }
    public sealed class PotentialMoney : IComponent { public int Value; }
    public sealed class CurrentMoney : IComponent { public int Value; }
    public sealed class GrabPoint : IComponent { public Transform Value; }

    [Event(Self), Cleanup(RemoveComponent)] public sealed class Attacking : IComponent { }
    [Event(Any), Cleanup(RemoveComponent)] public sealed class BroughtStacks : IComponent { }

    // Input Keys
    [Unique, Input] public sealed class Joystick : IComponent { }
    [Input] public sealed class Dragging : IComponent { }
    [Input] public sealed class TouchOffset : IComponent { public Vector2 Value; }
    [Game, Input, Event(Any), Cleanup(RemoveComponent)] public sealed class TouchClick : IComponent { public Vector2 Position; }
    [Input, Event(Any), Cleanup(RemoveComponent)] public sealed class StoppedDragging : IComponent { }
}
