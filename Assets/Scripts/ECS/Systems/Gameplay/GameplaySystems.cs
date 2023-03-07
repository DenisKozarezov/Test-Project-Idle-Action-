using Core.ECS.Systems.Player;

namespace Core.ECS.Systems
{
    public sealed class GameplaySystems : Feature
    {
        public GameplaySystems(Contexts contexts) : base(nameof(GameplaySystems))
        {
            Add(new InputSystems(contexts.input));
            Add(new PlayerSystems(contexts));
        }
    }
}