using UnityEngine;
using UnityEngine.InputSystem;
using Weapon;

namespace Character.Player
{
    [RequireComponent(typeof(CharacterAnimation))]
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerController : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private float smoothSpeed;

        #endregion

        #region Private

        private PlayerMovement _playerMovement;

        private CharacterAnimation _characterAnimation;

        private Vector3 _rawInput;

        private Vector3 _smoothInput;

        private MeleeWeapon _weapon;

        #endregion

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();

            _characterAnimation = GetComponent<CharacterAnimation>();
        }

        private void Update()
        {
            CalculateInputSmoothing();

            UpdateMovementDirection();

            UpdateMovementAnimation();
        }

        private void CalculateInputSmoothing()
        {
            _smoothInput = Vector3.Lerp(_smoothInput, _rawInput, smoothSpeed * Time.deltaTime);
        }

        private void UpdateMovementDirection()
        {
            _playerMovement.UpdateMovementDirection(_smoothInput);
        }

        private void UpdateMovementAnimation()
        {
            _characterAnimation.UpdateMovementAnimation(_smoothInput.magnitude);
        }

        public void SetWeapon(MeleeWeapon weapon)
        {
            _weapon = weapon;
        }

        public void MeleeAttackStart()
        {
            if (_weapon != null) _weapon.StartAttack();
        }

        public void MeleeAttackHit()
        {
            if (_weapon != null) _weapon.CheckCollision();
        }

        public void MeleeAttackAnd()
        {
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            var input = context.ReadValue<Vector2>();

            _rawInput = new Vector3(input.x, 0f, input.y);
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed) _characterAnimation.AttackAnimation();
        }
    }
}