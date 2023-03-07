using UnityEngine;
using Entitas;

namespace Core.ECS.Systems.Player
{
    public sealed class PlayerMoveSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _players;
        private readonly IGroup<InputEntity> _inputs;

        public PlayerMoveSystem(GameContext game, InputContext input)
        {
            _game = game;
            _players = game.GetGroup(GameMatcher.Player);
            _inputs = input.GetGroup(InputMatcher.Dragging);
        }

        private void Move(GameEntity player, Vector3 direction, float speed)
        {
            Vector3 currentPosition = player.rigidbody.Value.position;
            Vector3 newPosition = currentPosition + direction * speed * _game.time.Value.DeltaTime;
            player.ReplacePosition(newPosition);
            player.ReplaceDirection(direction);
        }
        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                foreach (GameEntity player in _players)
                {
                    Vector2 touchOffset = input.touchOffset.Value.normalized;
                    Vector3 direction = new Vector3(touchOffset.x, 0f, touchOffset.y);
                    float speed = player.movable.Value;

                    player.isMoving = direction.sqrMagnitude > 0f;
                    if (player.isMoving) Move(player, direction, speed);
                }
            }
        }
    }
}