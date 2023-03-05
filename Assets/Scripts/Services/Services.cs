using Core.ECS.ViewListeners;
using Zenject;

namespace Core.Services
{
    public struct Services
    {
        public ILogService Logger;
        public IIdentifierService Identifiers;
        //public IViewService ViewService;
        public ITimeService Time;
        public IInputService InputService;
        public IPhysicsService Physics;
        public IRegisterService<IViewController> CollisionRegistry;
        public DiContainer DiContainer;
    }
}