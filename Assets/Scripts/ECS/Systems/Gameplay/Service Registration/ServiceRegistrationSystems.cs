using Core.ECS.ViewListeners;
using Core.Services;

namespace Core.ECS.Systems
{
    public sealed class ServiceRegistrationSystems : Feature
    {
        public ServiceRegistrationSystems(Contexts contexts, Services.Services services)
         : base(nameof(ServiceRegistrationSystems))
        {
            GameContext game = contexts.game;
            InputContext input = contexts.input;

            Add(new RegisterServiceSystem<ITimeService>(services.Time, game.ReplaceTime));
            Add(new RegisterServiceSystem<IInputService>(services.InputService, input.ReplaceInput));
            Add(new RegisterServiceSystem<IPhysicsService>(services.Physics, game.ReplacePhysics));
            Add(new RegisterServiceSystem<IRegisterService<IViewController>>(services.CollisionRegistry, game.ReplaceCollisionRegistry));
            Add(new RegisterServiceSystem<IIdentifierService>(services.Identifiers, game.ReplaceIdentifiers));
        }
    }
}