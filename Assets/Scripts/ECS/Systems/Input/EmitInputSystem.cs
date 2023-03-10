using UnityEngine;
using Entitas;
using Core.Services;

namespace Core.ECS.Systems.Input
{
    public sealed class EmitInputSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly IGroup<InputEntity> _joystick;
        private readonly InputContext _inputContext;

        public EmitInputSystem(InputContext inputContext)
        {
            _inputContext = inputContext;
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

                if (inputSystem.IsTouch)
                {
                    GameEntity gameEntity = ECSExtensions.Empty();
                    gameEntity.ReplaceTouchClick(inputSystem.TouchPosition);
                    joystick.ReplaceTouchClick(inputSystem.TouchPosition);
                    joystick.ReplaceTouchOffset(inputSystem.TouchOffset);
                    gameEntity.isDestroyed = true;
                }
                else joystick.ReplaceTouchOffset(Vector2.zero);

                joystick.isDragging = inputSystem.IsDragging;
            }
        }
    }
}