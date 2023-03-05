using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Core.ECS.ViewListeners;
using static Entitas.CodeGeneration.Attributes.EventTarget;
using static Entitas.CodeGeneration.Attributes.CleanupMode;

namespace Core.ECS.Components
{
    public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
    
    // Unity Components
    public sealed class RigidbodyComponent : IComponent { public Rigidbody Value; }
    public sealed class ColliderComponent : IComponent { public Collider Value; }
    public sealed class AnimatorComponent : IComponent { public Animator Value; }
    public sealed class TransformComponent : IComponent { public Transform Value; }
    public sealed class SpriteRendererComponent : IComponent { public SpriteRenderer Value; }
    public sealed class ViewControllerComponent : IComponent { public IViewController Value; }

    // Tags
    public sealed class Player : IComponent { }

    [Event(Self)] public sealed class Grounded : IComponent { }
    [Event(Self)] public sealed class Moving : IComponent { }
    [Event(Self), Cleanup(DestroyEntity)] public sealed class Destroyed : IComponent { }
    [Event(Self), Cleanup(RemoveComponent)] public sealed class StoppedMoving : IComponent { }
    [Event(Self), Cleanup(RemoveComponent)] public sealed class Collided : IComponent { public int CollidedID; }
}