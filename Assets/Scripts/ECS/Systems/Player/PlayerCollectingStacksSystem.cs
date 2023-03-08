using System;
using System.Collections.Generic;
using Entitas;

namespace Core.ECS.Systems
{
    public sealed class PlayerCollectingStacksSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _players;
        public PlayerCollectingStacksSystem(GameContext game) : base(game)
        {
            _players = game.GetGroup(GameMatcher.Player);
        }
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Collided.Added());
        }
        protected override bool Filter(GameEntity entity)
        {
            return entity.hasWheatStack;
        }
        protected override void Execute(List<GameEntity> stacks)
        {
            foreach (GameEntity stack in stacks)
            {
                foreach (GameEntity player in _players)
                {
                    stack.isDestroyed = true;
                    stack.transform.Value.gameObject.layer = Constants.IgnoreRaycastLayer;

                    int newValue = Math.Min(player.currentWheatStacks.Value + 1, player.maxWheatStacks.Value);
                    player.ReplaceCurrentWheatStacks((byte)newValue);
                    player.isStackObtained = true;
                }
            }
        } 
    }
}
