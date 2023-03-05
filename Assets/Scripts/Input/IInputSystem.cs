namespace Core.Input
{
    public interface IInputSystem
    {
        bool IsEnabled { get; }
        void Enable();
        void Disable();
    }
}