using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.EventTarget;
using static Entitas.CodeGeneration.Attributes.CleanupMode;

namespace Core.ECS.Components
{
    // Tags
    public sealed class Player : IComponent { }

    // Input Keys
    [Unique, Input] public sealed class Joystick : IComponent { }
    [Input, Event(Any), Cleanup(RemoveComponent)] public sealed class TouchClick : IComponent { }
    [Input, Event(Any), Cleanup(RemoveComponent)] public sealed class StoppedDragging : IComponent { }
    [Input] public sealed class Dragging : IComponent { }
}
