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

        [SerializeField] private float attackMovementMultiplier = .75f;

        #endregion

        #region Private

        private PlayerMovement _playerMovement;

        private CharacterAnimation _characterAnimation;

        private Vector3 _rawMoveInput;

        private Vector3 _smoothMoveInput;

        private MeleeWeapon _weapon;

        private bool _attacking;

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
            _smoothMoveInput = Vector3.Lerp(_smoothMoveInput, _rawMoveInput, smoothSpeed * Time.deltaTime);

            if (_attacking) _smoothMoveInput *= attackMovementMultiplier;
        }

        private void UpdateMovementDirection()
        {
            _playerMovement.UpdateMovementDirection(_smoothMoveInput);
        }

        private void UpdateMovementAnimation()
        {
            _characterAnimation.UpdateMovementAnimation(_smoothMoveInput.magnitude);
        }

        public void SetWeapon(MeleeWeapon weapon)
        {
            _weapon = weapon;
        }

        public void MeleeAttackStart()
        {
            _attacking = true;

            if (_weapon != null) _weapon.StartAttack();
        }

        public void MeleeAttackHit()
        {
            if (_weapon != null) _weapon.CheckCollision();
        }

        public void MeleeAttackEnd()
        {
            _attacking = false;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            var input = context.ReadValue<Vector2>();

            _rawMoveInput = new Vector3(input.x, 0f, input.y);
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed) _characterAnimation.AttackAnimation();
        }
    }
}