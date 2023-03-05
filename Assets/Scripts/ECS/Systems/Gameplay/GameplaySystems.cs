namespace Core.ECS.Systems
{
    public sealed class GameplaySystems : Feature
    {
        public GameplaySystems(Contexts contexts, Services.Services services) : base(nameof(GameplaySystems))
        {
            Add(new EmitInputSystem(contexts.input));
        }
    }
}