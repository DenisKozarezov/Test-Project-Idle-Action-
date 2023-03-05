namespace Core.Services
{
    public interface IInputService
    {
        bool IsEnabled { get; }
        void Enable();
        void Disable();
    }
}