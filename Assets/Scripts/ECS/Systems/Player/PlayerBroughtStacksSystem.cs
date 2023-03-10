using System.Collections.Generic;
using Entitas;

namespace Core.ECS.Systems
{
    public sealed class PlayerBroughtStacksSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _players;
        private readonly IWheatStacksFactory _factory;
        public PlayerBroughtStacksSystem(GameContext game, IWheatStacksFactory factory) : base(game)
        {
            _players = game.GetGroup(GameMatcher.Player);
            _factory = factory;
        }
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.BroughtStacks.Added());
        }
        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer;
        }
        protected override void Execute(List<GameEntity> stacks)
        {
            foreach (GameEntity player in _players)
            {
                if (player.potentialMoney.Value == 0) continue;

                int newValue = player.currentMoney.Value + player.potentialMoney.Value;
                player.ReplaceCurrentMoney(newValue);
                player.ReplacePotentialMoney(0);
                player.ReplaceCurrentWheatStacks(0);

                //_factory.Clear();
            }
        }
    }
}
