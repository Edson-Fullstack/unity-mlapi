using System;
using MLAPI;
using UnityEngine;
using UnityEngine.InputSystem;
using Logger = _Project.Scripts.Utils.Logger;

namespace _Project.Scripts.Character
{
    public class PlayerBehavior : NetworkedBehaviour, PlayerControl.IPlayerActions 
    {
        private Rigidbody _rigidbody;
        public float speed = 9f;
        public float jump = 3f;
        public float jumpscale = 125;

        private void Awake()
        {
            _rigidbody = GetComponentInChildren<Rigidbody>();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (IsLocalPlayer)
            {
                Vector2 input = context.ReadValue<Vector2>();
                Vector3 move = new Vector3(input.x, 0, input.y);
                Logger.Log($"move{input}");
                _rigidbody.velocity = move * speed;
            }

        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (IsLocalPlayer)
            {
                _rigidbody.AddForce(new Vector3(0, jump * jumpscale, 0),
                    ForceMode.Impulse);
            }
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (IsLocalPlayer)
            {
                Logger.Log("10");
            }
        }
    }
}