using Zenject;
using Core.ECS.ViewListeners;

namespace Core.Services
{
    public struct Services
    {
        public IIdentifierService Identifiers;
        public ITimeService Time;
        public IInputService InputService;
        public IPhysicsService Physics;
        public IRegisterService<IViewController> CollisionRegistry;
        public DiContainer DiContainer;
    }
}
