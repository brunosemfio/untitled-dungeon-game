﻿using UnityEngine;
using UnityEngine.InputSystem;
using Weapon;

namespace Player
{
    [RequireComponent(typeof(PlayerAnimation))]
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerController : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private float smoothSpeed;

        #endregion

        #region Private

        private PlayerMovement _playerMovement;

        private PlayerAnimation _playerAnimation;

        private Vector3 _rawInput;

        private Vector3 _smoothInput;

        private MeleeWeapon _weapon;

        #endregion

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();

            _playerAnimation = GetComponent<PlayerAnimation>();
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
            _playerAnimation.UpdateMovementAnimation(_smoothInput.magnitude);
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
            if (context.performed) _playerAnimation.AttackAnimation();
        }
    }
}