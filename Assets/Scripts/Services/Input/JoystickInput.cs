using UnityEngine;
using Zenject;

namespace Core.Services
{
    public sealed class JoystickInput : IInputService, IInitializable, ITickable, ILateDisposable
    {
        private readonly PlayerControls _playerControls;

        private Vector2 _oldPosition;

        public bool IsEnabled => _playerControls.Player.enabled;
        public bool IsDragging => IsTouch && TouchOffset != Vector2.zero;
        public bool IsTouch => _playerControls.Player.TouchPress.IsPressed();
        public Vector2 TouchPosition => _playerControls.Player.TouchPosition.ReadValue<Vector2>();
        public Vector2 TouchOffset { get; set; }

        public JoystickInput() 
        {
            _playerControls = new PlayerControls();
            _playerControls.Player.TouchPress.started += (ctx) => _oldPosition = TouchPosition;
        }

        public void Enable() => _playerControls.Enable();
        public void Disable() => _playerControls.Disable();
        public void Initialize() => Enable();
        public void Tick()
        {
            if (IsTouch)
                TouchOffset = TouchPosition - _oldPosition;
            else
                TouchOffset = Vector2.zero;
        }
        public void LateDispose() => Disable();
    }
}