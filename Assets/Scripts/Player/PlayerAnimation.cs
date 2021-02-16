using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        #region Private

        private Animator _animator;

        private int _speedHash;

        private int _attackHash;

        private int _stateTimeHash;

        #endregion

        private void Awake()
        {
            _animator = GetComponent<Animator>();

            _speedHash = Animator.StringToHash("speed");

            _attackHash = Animator.StringToHash("attack");

            _stateTimeHash = Animator.StringToHash("stateTime");
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