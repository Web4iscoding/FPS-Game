using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    // Classes initiatizations
    private PlayerMotor motor;
    private PlayerLook look;

    // Initializing
    private void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        // Execute method when action is performed
        onFoot.Jump.performed += cfx => motor.Jump();
        onFoot.Sprint.performed += cfx => motor.Sprint();
        onFoot.Crouch.performed += cfx => motor.Crouch();
    }

    // Update is called once per frame
    private void Update()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    // LateUpdate is called after Update
    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    // Enabling onFoot Action Map
    private void OnEnable()
    {
        onFoot.Enable();
    }

    // Disabling onFoot Action Map
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
