using UnityEngine;

namespace Core.Services
{
    public interface IInputService
    {
        bool IsEnabled { get; }
        bool IsDragging { get; }
        ref Vector3 Direction { get; } 
        void Enable();
        void Disable();
    }
}