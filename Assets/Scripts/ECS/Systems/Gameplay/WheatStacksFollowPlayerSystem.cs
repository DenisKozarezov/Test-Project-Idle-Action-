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
            _stacks = game.GetGroup(GameMatcher.AllOf(GameMatcher.WheatStack, GameMatcher.Collected));
            _game = game;
        }
        public void Execute()
        {
            foreach (GameEntity player in _players)
            {
                foreach (GameEntity stack in _stacks)
                {                 
                    stack.transform.Value.gameObject.layer = Constants.IgnoreRaycastLayer;
                    stack.rigidbody.Value.constraints = RigidbodyConstraints.FreezeAll;
                    stack.rigidbody.Value.useGravity = false;
                    GrabStack(stack, player.grabPoint.Value);
                }
            }
        } 

        private void GrabStack(GameEntity entity, Transform grabPoint)
        {
            Transform stack = entity.transform.Value;

            Vector3 direction = (grabPoint.position - stack.position).normalized;
            float distance = (grabPoint.position - stack.position).sqrMagnitude;    
            Vector3 velocity = Vector3.ClampMagnitude(5f * direction * _game.time.Value.DeltaTime, distance);

            stack.position += velocity;
                        
            if (distance <= 1E-2)
            {
                stack.SetParent(grabPoint);
                entity.isDestroyed = true;
            }
        }
    }
}
