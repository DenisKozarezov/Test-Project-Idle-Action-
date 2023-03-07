using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.EventTarget;
using static Entitas.CodeGeneration.Attributes.CleanupMode;

namespace Core.ECS.Components
{
    // Tags
    public sealed class Player : IComponent { }

    [Event(Self), Cleanup(RemoveComponent)] public sealed class Attacking : IComponent { }

    // Input Keys
    [Unique, Input] public sealed class Joystick : IComponent { }
    [Input] public sealed class Dragging : IComponent { }
    [Input] public sealed class TouchOffset : IComponent { public Vector2 Value; }
    [Input, Event(Any), Cleanup(RemoveComponent)] public sealed class TouchClick : IComponent { }
    [Input, Event(Any), Cleanup(RemoveComponent)] public sealed class StoppedDragging : IComponent { }
}
