using UnityEngine;
using Entitas;
using Core.Units;

namespace Core.ECS.ViewListeners
{
    public class AttackListener : MonoBehaviour, IEventListener, IAttackingListener
    {
        private UnitAnimator _animator;
        private GameEntity _entity;

        public void RegisterListeners(IEntity entity)
        {
            _entity = (GameEntity)entity;
            _entity.AddAttackingListener(this);

            _animator = GetComponent<UnitAnimator>();
        }
        public void UnregisterListeners() => _entity.RemoveAttackingListener();
        public void OnAttacking(GameEntity entity) => _animator.PlayAttack();
    }
}