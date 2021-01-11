using MLAPI;
using UnityEngine;

namespace _Project.Scripts.Character
{
    public class ControlBehavior : NetworkedBehaviour
    {
        [SerializeField] private PlayerControl _control;
        public void Awake()
        {
            _control = new PlayerControl();

        }

        public void OnEnable()
        {
            _control.Player.Enable();
            _control.Player.Attack.performed += GetComponent<PlayerBehavior>().OnAttack;
            _control.Player.Jump.performed += GetComponent<PlayerBehavior>().OnJump;
            _control.Player.Move.performed += GetComponent<PlayerBehavior>().OnMove;
        }

        public void OnDisable()
        {
            _control.Player.Attack.performed -= GetComponent<PlayerBehavior>().OnAttack;
            _control.Player.Jump.performed -= GetComponent<PlayerBehavior>().OnJump;
            _control.Player.Move.performed -= GetComponent<PlayerBehavior>().OnMove;
            _control.Player.Disable();
        }
    }
}

