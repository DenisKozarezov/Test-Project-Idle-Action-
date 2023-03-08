using System.Collections.Generic;
using Entitas;
using Core.ECS.Behaviours;

namespace Core.ECS.Systems
{
    public sealed class VegetationDroppingStacksSystem : ReactiveSystem<GameEntity>
    {
        private readonly WheatStackBehaviour.Factory _factory;
        public VegetationDroppingStacksSystem(GameContext game, WheatStackBehaviour.Factory factory) : base(game)
        {
            _factory = factory;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CanBeCut.Removed());
        }
        protected override bool Filter(GameEntity entity)
        {
            return entity.isVegetation && entity.hasIsGrowing;
        }
        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                var stack = _factory.Create(entity.position.Value);
            }
        } 
    }
}
