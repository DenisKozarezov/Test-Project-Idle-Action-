using Core.ECS.Behaviours;

namespace Core.ECS.Systems.Player
{
    public sealed class PlayerSystems : Feature
    {
        public PlayerSystems(Contexts contexts, Services.Services services) : base(nameof(PlayerSystems))
        {
            var wheatFactory = services.DiContainer.Resolve<WheatStackBehaviour.Factory>();

            Add(new PlayerMoveSystem(contexts.game, contexts.input));
            Add(new PlayerStoppedMovingSystem(contexts.game, contexts.input));
            Add(new PlayerCutVegetationSystem(contexts.game));
            Add(new PlayerCollectingStacksSystem(contexts.game));
            Add(new PlayerBroughtStacksSystem(contexts.game, wheatFactory));
        }
    }
}