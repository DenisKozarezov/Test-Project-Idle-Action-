using Zenject;
using Core.ECS.Systems;
using Core.ECS.ViewListeners;
using Core.Services;

namespace Core.ECS
{
    public sealed class ECSStartup : ITickable
    {
        private readonly AllSystems _allSystems;

        public ECSStartup(
            IInputService inputSystem,
            IRegisterService<IViewController> collisionRegistry,
            ITimeService time,
            IPhysicsService physics,
            IIdentifierService identifier)
        {
            Contexts contexts = Contexts.sharedInstance;

            Services.Services allServices = new Services.Services
            {
                Identifiers = identifier,
                Time = time,
                InputService = inputSystem,
                Physics = physics,
                CollisionRegistry = collisionRegistry,
            };

            _allSystems = new AllSystems(contexts, allServices);
            _allSystems.Initialize();
        }
        public void Tick()
        {
            _allSystems.Execute();
            _allSystems.Cleanup();
        }
    }
}