using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private float multiplierRandomRange;

        #endregion
        
        #region Private
        
        private readonly int _speedHash = Animator.StringToHash("speed");

        private readonly int _attackHash = Animator.StringToHash("attack");

        private readonly int _stateTimeHash = Animator.StringToHash("stateTime");
        
        private readonly int _multiplierHash = Animator.StringToHash("multiplier");
        
        private Animator _animator;

        #endregion

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _animator.SetFloat(_multiplierHash, 1f + Random.Range(-multiplierRandomRange, multiplierRandomRange));
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