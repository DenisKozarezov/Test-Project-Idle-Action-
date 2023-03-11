using UnityEngine;
using Entitas;

namespace Core.ECS.Systems
{
    public sealed class WheatStacksFollowPlayerSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _players;
        private readonly IGroup<GameEntity> _stacks;
        private readonly GameContext _game;
        public WheatStacksFollowPlayerSystem(GameContext game)
        {
            _players = game.GetGroup(GameMatcher.Player);
            _stacks = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.WheatStack, GameMatcher.Collected)
                .NoneOf(GameMatcher.Grabbed));
            _game = game;
        }
        public void Execute()
        {
            foreach (GameEntity player in _players)
            {
                foreach (GameEntity stack in _stacks.GetEntities())
                {
                    Transform transform = stack.transform.Value;

                    transform.gameObject.layer = Constants.IgnoreRaycastLayer;
                    stack.rigidbody.Value.constraints = RigidbodyConstraints.FreezeAll;
                    stack.rigidbody.Value.useGravity = false;

                    GrabStack(stack, player.grabPoint.Value);
                }
            }
        }

        private void GrabStack(GameEntity stack, Transform grabPoint)
        {
            Transform transform = stack.transform.Value;

            Vector3 direction = (grabPoint.position - transform.position).normalized;
            float distance = (grabPoint.position - transform.position).sqrMagnitude;
            Vector3 velocity = Vector3.ClampMagnitude(4f * direction * _game.time.Value.DeltaTime, distance);

            transform.position += velocity;

            if (distance <= 1E-1)
            {
                transform.SetParent(grabPoint, true);
                stack.isGrabbed = true;
            }
        }
    }
}
