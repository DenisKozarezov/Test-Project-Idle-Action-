using Core.ECS.Systems.Input;

namespace Core.ECS.Systems
{
    public sealed class InputSystems : Feature
    {
        public InputSystems(InputContext input) : base(nameof(InputSystems))
        {
            Add(new EmitInputSystem(input));
            Add(new JoystickStoppedDraggingSystem(input));
        }
    }
}