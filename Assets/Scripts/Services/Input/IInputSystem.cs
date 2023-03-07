using UnityEngine;

namespace Core.Services
{
    public interface IInputService
    {
        bool IsEnabled { get; }
        bool IsDragging { get; }
        bool IsTouch { get; }
        Vector2 TouchPosition { get; }
        Vector2 TouchOffset { get; }
        void Enable();
        void Disable();
    }
}