using Entitas;
using Entitas.CodeGeneration.Attributes;
using Core.Services;
using Core.ECS.ViewListeners;

namespace Core.ECS.Components
{
    [Unique] public sealed class Time : IComponent { public ITimeService Value; }
    [Unique] public sealed class Physics : IComponent { public IPhysicsService Value; }
    [Unique] public sealed class CollisionRegistry : IComponent { public IRegisterService<IViewController> Value; }
    [Unique] public sealed class Identifiers : IComponent { public IIdentifierService Value; }
    [Unique, Input] public sealed class Input : IComponent { public IInputService Value; }
}