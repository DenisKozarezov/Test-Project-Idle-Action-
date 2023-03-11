using System.Collections;
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
        [SerializeField]
        private GameObject _scythe;

        private void Awake() => _scythe.SetActive(false);

        public void PlayRun() => _animator.SetBool(_runningHash, true);
        public void PlayGrounded() => _animator.SetBool(_onGroundHash, true);
        public void PlayAttack()
        {
            if (_animator.GetBool(_attackingHash)) 
                StopCoroutine(AttackCoroutine());
            else
                StartCoroutine(AttackCoroutine());
        }
        private IEnumerator AttackCoroutine()
        {
            _scythe.SetActive(true);
            _animator.SetBool(_attackingHash, true);
            yield return new WaitForSeconds(1.3f);
            _scythe.SetActive(false);
            _animator.SetBool(_attackingHash, false);
        }
        public void PlayIdle()
        {
            _animator.SetFloat(_movingLeftHash, 0f);
            _animator.SetFloat(_movingRightHash, 0f);
            _animator.SetBool(_runningHash, false);
        }
    }
}