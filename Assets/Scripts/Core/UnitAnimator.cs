using UnityEngine;

namespace Core.Units
{
    public class UnitAnimator : MonoBehaviour
    {
        private readonly int _onGroundHash = Animator.StringToHash("OnGround");
        private readonly int _runningHash = Animator.StringToHash("IsMoving");
        private readonly int _attackingHash = Animator.StringToHash("IsAttacking");
        private readonly int _movingLeftHash = Animator.StringToHash("MovingLeft");
        private readonly int _movingRightHash = Animator.StringToHash("MovingRight");

        [SerializeField]
        private Animator _animator;

        public void PlayRun() => _animator.SetBool(_runningHash, true);
        public void PlayGrounded() => _animator.SetBool(_onGroundHash, true);
        public void PlayAttack() => _animator.SetBool(_attackingHash, true);
        public void PlayIdle()
        {
            _animator.SetFloat(_movingLeftHash, 0f);
            _animator.SetFloat(_movingRightHash, 0f);
            _animator.SetBool(_runningHash, false);
        }
    }
}