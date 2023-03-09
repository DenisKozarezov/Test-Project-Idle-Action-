using Core.ECS.Behaviours;
using Core.ECS.Systems.Player;

namespace Core.ECS.Systems
{
    public sealed class GameplaySystems : Feature
    {
        public GameplaySystems(Contexts contexts, Services.Services services) : base(nameof(GameplaySystems))
        {
            var wheatFactory = services.DiContainer.Resolve<WheatStackBehaviour.Factory>();

            Add(new InputSystems(contexts.input));
            Add(new PlayerSystems(contexts));
            Add(new VegetationDroppingStacksSystem(contexts.game, wheatFactory));
            Add(new WheatStackObtainedSystem(contexts.game));
        }
    }
}