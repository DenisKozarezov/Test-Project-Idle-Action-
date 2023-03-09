using UnityEngine;
using Entitas;

namespace Core.ECS.Systems.Player
{
    public sealed class PlayerMoveSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _players;
        private readonly IGroup<InputEntity> _inputs;

        private readonly int _movingLeftHash = Animator.StringToHash("MovingLeft");
        private readonly int _movingRightHash = Animator.StringToHash("MovingRight");

        private float deltaTime => _game.time.Value.DeltaTime;

        public PlayerMoveSystem(GameContext game, InputContext input)
        {
            _game = game;
            _players = game.GetGroup(GameMatcher.Player);
            _inputs = input.GetGroup(InputMatcher.Dragging);
        }

        private void Move(GameEntity player, Vector3 direction, float speed)
        {
            Vector3 currentPosition = player.rigidbody.Value.position;
            Vector3 newPosition = currentPosition + direction * speed * deltaTime;
            player.ReplacePosition(newPosition);
            player.ReplaceDirection(direction);
        }
        private void UpdateAnimationFloats(Animator animator, Vector3 direction)
        {
            animator.SetFloat(_movingLeftHash, direction.x, 0.1f, deltaTime);
            animator.SetFloat(_movingRightHash, direction.z, 0.1f, deltaTime);
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

                    UpdateAnimationFloats(player.animator.Value, direction);

                    player.isMoving = direction.sqrMagnitude > 0f;
                    if (player.isMoving) Move(player, direction, speed);
                }
            }
        }
    }
}