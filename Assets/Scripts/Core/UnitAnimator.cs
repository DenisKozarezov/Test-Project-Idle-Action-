using UnityEngine;

namespace Core.Units
{
    public class UnitAnimator : MonoBehaviour
    {
        private readonly int _onGroundHash = Animator.StringToHash("OnGround");
        private readonly int _runningHash = Animator.StringToHash("IsRunning");

        [SerializeField]
        private Animator _animator;

        public void PlayRun() => _animator.SetBool(_runningHash, true);
        public void PlayGrounded() => _animator.SetBool(_onGroundHash, true);
        public void PlayIdle() => _animator.SetBool(_runningHash, false);
    }
}