namespace Core.ECS.Systems.UI
{
    public sealed class UISystems : Feature
    {
        public UISystems(Contexts contexts, Services.Services services) : base(nameof(UISystems))
        {
            var coinsFactory = services.DiContainer.Resolve<ICoinsFactory>();

            Add(new CoinsAnimationSystem(contexts.game, coinsFactory));
        }
    }
}