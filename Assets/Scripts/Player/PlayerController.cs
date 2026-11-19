using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(InputManager))]
public class PlayerController : MonoBehaviour
{
    private PlayerMovement _movement;
    private InputManager _input;

    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _input = GetComponent<InputManager>();
    }

    private void FixedUpdate()
    {
        _movement.UpdateMovement(_input.MoveDirection);
        if (_input.Jump)
        {
            //_movement.JumpUpdate();
        }
    }
}
