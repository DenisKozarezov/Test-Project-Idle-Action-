using System.Collections.Generic;
using UnityEngine;
using Entitas;

namespace Core.ECS.Systems
{
    public sealed class WheatStacksFollowPlayerSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _players;
        private readonly IGroup<GameEntity> _stacks;
        private readonly GameContext _game;
        private readonly List<Transform> _transforms = new List<Transform>();
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
                    stack.isDestroyed = true;
                    _transforms.Add(stack.transform.Value);
                }
                GrabStacks(player.grabPoint.Value);
            }
        } 

        private void GrabStacks(Transform grabPoint)
        {
            for (int i = 0; i < _transforms.Count; i++)
            {
                Transform stack = _transforms[i];
                Vector3 direction = (grabPoint.position - stack.position).normalized;
                float distance = (grabPoint.position - stack.position).sqrMagnitude;
                Vector3 velocity = Vector3.ClampMagnitude(4f * direction * _game.time.Value.DeltaTime, distance);

                stack.position += velocity;

                if (distance <= 1E-2)
                {
                    stack.SetParent(grabPoint);
                    _transforms.RemoveAt(i);
                }
            }
        }
    }
}
