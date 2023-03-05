using Zenject;

namespace Core.Services
{
    public sealed class JoystickInput : IInputService, IInitializable, ITickable, ILateDisposable
    {
        private readonly PlayerControls _playerControls;

        public bool IsEnabled => _playerControls.Player.enabled;

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
           
        }
        public void LateDispose() => Disable();
    }
}