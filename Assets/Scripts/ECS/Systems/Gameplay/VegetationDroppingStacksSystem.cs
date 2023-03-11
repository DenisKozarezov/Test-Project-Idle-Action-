using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace Core.ECS.Systems
{
    public sealed class VegetationDroppingStacksSystem : ReactiveSystem<GameEntity>
    {
        private readonly IWheatStacksFactory _factory;
        public VegetationDroppingStacksSystem(GameContext game, IWheatStacksFactory factory) : base(game)
        {
            _factory = factory;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CanBeSliced.Removed());
        }
        protected override bool Filter(GameEntity entity)
        {
            return entity.isVegetation && entity.hasIsGrowing;
        }
        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                _factory.Create(entity.collisionContact.Point + Vector3.up);
            }
        } 
    }
}
