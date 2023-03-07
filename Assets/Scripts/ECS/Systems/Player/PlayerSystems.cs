namespace Core.ECS.Systems.Player
{
    public sealed class PlayerSystems : Feature
    {
        public PlayerSystems(Contexts contexts) : base(nameof(PlayerSystems))
        {
            Add(new PlayerMoveSystem(contexts.game, contexts.input));
            Add(new PlayerStoppedMovingSystem(contexts.game, contexts.input));
            Add(new PlayerCutVegetationSystem(contexts.game));
        }
    }
}