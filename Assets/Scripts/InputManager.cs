using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    private PlayerController pc;
    private PlayerLook look;
    private void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        onFoot.Jump.performed += ctx => pc.jump();
        pc = GetComponent<PlayerController>();
        look = GetComponent<PlayerLook>();
    }

    void FixedUpdate()
    {
        pc.processMove(onFoot.Movement.ReadValue<Vector2>()); // process move is a function in characterController component.
    }

    private void LateUpdate()
    {
        look.processLook(onFoot.Look.ReadValue<Vector2>()); // process look is a function in playerLook component.
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
