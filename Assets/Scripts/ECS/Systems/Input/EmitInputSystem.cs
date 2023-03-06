using Entitas;
using Core.Services;

namespace Core.ECS.Systems
{
    public sealed class EmitInputSystem : IInitializeSystem, IExecuteSystem
    {
        //private readonly IGroup<InputEntity> _touchClick;
        private readonly IGroup<InputEntity> _joystick;
        private readonly InputContext _inputContext;

        public EmitInputSystem(InputContext inputContext)
        {
            _inputContext = inputContext;
            //_touchClick = inputContext.GetGroup(InputMatcher.TouchClick);
            _joystick = inputContext.GetGroup(InputMatcher.Joystick);
        }

        public void Initialize()
        {
            _inputContext.isJoystick = true;
        }
        public void Execute()
        {
            foreach (InputEntity joystick in _joystick)
            {
                IInputService inputSystem = _inputContext.input.Value;

                joystick.isDragging = inputSystem.IsDragging;
            }
        }
    }
}