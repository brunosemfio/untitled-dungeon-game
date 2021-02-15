using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private float moveSpeed;

        [SerializeField] private float turnSpeed;

        #endregion

        #region Private

        private CharacterController _controller;

        private Vector3 _direction;

        #endregion

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            Move();
            Turn();
        }

        private void Move()
        {
            _controller.SimpleMove(_direction * moveSpeed);
        }

        private void Turn()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction),
                turnSpeed * Time.deltaTime);
        }

        public void UpdateMovementDirection(Vector3 direction)
        {
            _direction = direction;
        }
    }
}