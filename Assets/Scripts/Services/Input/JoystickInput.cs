using UnityEngine;
using Zenject;

namespace Core.Services
{
    public sealed class JoystickInput : IInputService, IInitializable, ITickable, ILateDisposable
    {
        private readonly PlayerControls _playerControls;
        public Vector3 _direction;

        public bool IsEnabled => _playerControls.Player.enabled;
        public bool IsDragging => Direction != Vector3.zero;
        public ref Vector3 Direction => ref _direction;

        public JoystickInput() 
        {
            _playerControls = new PlayerControls();
        }

        public void Enable() => _playerControls.Enable();
        public void Disable()
        {
            _playerControls.Disable();
        }
        public void Initialize()
        {
            Enable();
        }
        public void Tick()
        {
            Vector2 moveInput = _playerControls.Player.Move.ReadValue<Vector2>();
            _direction = new Vector3(moveInput.x, 0f, moveInput.y);
        }
        public void LateDispose() => Disable();
    }
}