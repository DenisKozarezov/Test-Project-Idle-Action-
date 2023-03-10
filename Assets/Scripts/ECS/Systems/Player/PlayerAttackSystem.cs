using System.Collections.Generic;
using Entitas;

namespace Core.ECS.Systems.Player
{
    public sealed class PlayerAttackSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _players;
        public PlayerAttackSystem(GameContext game) : base(game)
        {
            _players = game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Collided.Added());
        }
        protected override bool Filter(GameEntity entity)
        {
            return entity.isVegetation && !entity.hasIsGrowing;
        }
        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity player in _players)
            {
                if (entities.Count == 0) continue;

                player.isAttacking = true;
            }
        }
    }
}
