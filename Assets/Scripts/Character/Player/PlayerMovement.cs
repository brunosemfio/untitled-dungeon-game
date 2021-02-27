using UnityEngine;

namespace Character.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private float moveSpeed;

        [SerializeField] private float turnSpeed;

        #endregion

        #region Private

        private Camera _cam;

        private CharacterController _controller;

        private Vector3 _direction;

        #endregion

        private void Awake()
        {
            _cam = Camera.main;

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
            if (_direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction),
                    turnSpeed * Time.deltaTime);
            }
        }

        public void UpdateMovementDirection(Vector3 direction)
        {
            var t = _cam.transform;

            var forward = t.forward;
            var right = t.right;

            forward.y = 0f;
            right.y = 0f;

            _direction = forward * direction.z + right * direction.x;
        }
    }
}