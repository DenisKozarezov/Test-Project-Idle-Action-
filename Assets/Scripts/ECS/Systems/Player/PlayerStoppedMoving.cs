using System.Collections.Generic;
using Entitas;

namespace Core.ECS.Systems.Player
{
    public sealed class PlayerStoppedMovingSystem : ReactiveSystem<InputEntity>
    {
        private readonly IGroup<GameEntity> _players;
        public PlayerStoppedMovingSystem(GameContext game, InputContext input) : base(input) 
        {
            _players = game.GetGroup(GameMatcher.Player);
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.StoppedDragging.Added());
        }
        protected override bool Filter(InputEntity entity)
        {
            return entity.isJoystick;
        }
        protected override void Execute(List<InputEntity> entities)
        {
            foreach (InputEntity entity in entities)
            {
                foreach (GameEntity player in _players)
                {
                    player.isMoving = !entity.isStoppedDragging;
                    player.isStoppedMoving = entity.isStoppedDragging;
                }
            }
        }
    }
}