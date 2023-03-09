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
            return context.CreateCollector(GameMatcher.Collided.AddedOrRemoved());
        }
        protected override bool Filter(GameEntity entity)
        {
            return entity.hasWheatStack && !entity.isCollected;
        }
        protected override void Execute(List<GameEntity> stacks)
        {
            foreach (GameEntity stack in stacks)
            {
                foreach (GameEntity player in _players)
                {
                    byte newValue = (byte)(player.currentWheatStacks.Value + 1);

                    if (newValue >= player.maxWheatStacks.Value) continue;

                    stack.isCollected = true;

                    player.ReplaceCurrentWheatStacks(newValue);
                    player.isStackObtained = true;
                }
            }
        } 
    }
}
