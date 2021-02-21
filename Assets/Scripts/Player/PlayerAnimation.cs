using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        #region Private
        
        private readonly int _speedHash = Animator.StringToHash("speed");

        private readonly int _attackHash = Animator.StringToHash("attack");

        private readonly int _stateTimeHash = Animator.StringToHash("stateTime");
        
        private Animator _animator;

        #endregion

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            var time = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

            _animator.SetFloat(_stateTimeHash, Mathf.Repeat(time, 1f));
        }

        public void UpdateMovementAnimation(float speed)
        {
            _animator.SetFloat(_speedHash, speed);
        }

        public void AttackAnimation()
        {
            _animator.SetTrigger(_attackHash);
        }
    }
}