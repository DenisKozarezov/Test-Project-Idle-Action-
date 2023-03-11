using Core.ECS.Systems.UI;

namespace Core.ECS.Systems
{
    public sealed class AllSystems : Feature
    {
        public AllSystems(Contexts contexts, Services.Services services) : base(nameof(GameplaySystems))
        {
            Add(new ServiceRegistrationSystems(contexts, services));
            Add(new GameplaySystems(contexts, services));
            Add(new UISystems(contexts, services));
            Add(new GameEventSystems(contexts));
            Add(new GameCleanupSystems(contexts));
            Add(new InputEventSystems(contexts));
            Add(new InputCleanupSystems(contexts));
        }
    }
}