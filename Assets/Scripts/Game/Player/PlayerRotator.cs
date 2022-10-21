using System;
using Cinemachine;
using UnityEngine;

namespace P3D.Game
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private CinemachineFreeLook _freeLook;
        [SerializeField] private PlayerMovement _movement;

        private void Awake()
        {
            // TODO: Remove later
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (_movement.Velocity.sqrMagnitude > 0)
            {
                Quaternion targetRotation = Quaternion.Euler(0, _freeLook.m_XAxis.Value, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.5f);
            }
        }
    }
}