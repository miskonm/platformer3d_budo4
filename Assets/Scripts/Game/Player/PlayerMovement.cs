using UnityEngine;

namespace P3D.Game
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Base Settings")]
        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _gravityMultiplier = 1;

        [Header("Grounded")]
        [SerializeField] private Transform _checkGroundTransform;
        [SerializeField] private float _checkGroundRadius;
        [SerializeField] private LayerMask _checkGroundMask;

        [Header("Jump")]
        [SerializeField] private float _jumpHeight = 2f;

        private Transform _cachedTransform;
        private Vector3 _fallVector;

        public Vector3 Velocity { get; private set; }
        public bool IsGrounded { get; private set; }

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 moveVector = _cachedTransform.right * horizontal + _cachedTransform.forward * vertical;
            moveVector *= _speed;

            _controller.Move(moveVector * Time.deltaTime);
            _animation.SetSpeedHorizontal(moveVector.magnitude);

            IsGrounded = Physics.CheckSphere(_checkGroundTransform.position, _checkGroundRadius, _checkGroundMask);

            if (IsGrounded && _fallVector.y < 0)
                _fallVector.y = 0;

            float gravity = Physics.gravity.y * _gravityMultiplier;

            if (IsGrounded && Input.GetButtonDown("Jump"))
            {
                _fallVector.y = Mathf.Sqrt(_jumpHeight * -2f * gravity);
            }

            _fallVector.y += gravity * Time.deltaTime;
            _controller.Move(_fallVector * Time.deltaTime);


            Velocity = moveVector;

            _animation.SetIsGrounded(IsGrounded);
            _animation.SetSpeedVertical(_fallVector.y);
        }
    }
}