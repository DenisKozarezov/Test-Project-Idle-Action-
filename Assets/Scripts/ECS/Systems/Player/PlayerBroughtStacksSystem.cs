using System.Collections.Generic;
using Entitas;

namespace Core.ECS.Systems
{
    public sealed class PlayerBroughtStacksSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _players;   
        public PlayerBroughtStacksSystem(GameContext game) : base(game)
        {
            _players = game.GetGroup(GameMatcher.Player);
        }
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.BroughtStacks.Removed());
        }
        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer;
        }
        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity player in _players)
            {
                if (player.currentWheatStacks.Value == 0) continue;

                int newValue = player.currentMoney.Value + player.potentialMoney.Value;
                player.ReplaceCurrentMoney(newValue);
                player.ReplacePotentialMoney(0);
                player.ReplaceCurrentWheatStacks(0);
            }
        }
    }
}
