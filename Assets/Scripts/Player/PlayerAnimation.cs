using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        #region Private

        private Animator _animator;
        
        private int _speedHash;

        #endregion

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            
            _speedHash = Animator.StringToHash("speed");
        }

        public void UpdateMovementAnimation(float speed)
        {
            _animator.SetFloat(_speedHash, speed);
        }
    }
}