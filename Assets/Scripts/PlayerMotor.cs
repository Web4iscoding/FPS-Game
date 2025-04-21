using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5;
    private bool isGrounded;
    private bool isSprinting;

    // Crouch
    private bool isCrouching;
    private float crouchTimer;
    private bool lerpCrouch;

    // Jump
    public float gravity = -9.8f;
    public float jumpHeight = 2f;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        isGrounded = controller.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float i = crouchTimer / 1;
            i *= i;
            if (isCrouching)
            {
                controller.height = Mathf.Lerp(controller.height, 1, i);
                speed = 2.5f;
            }
            else
            {
                controller.height = Mathf.Lerp(controller.height, 2, i);
                speed = 5;
            }
            if (i > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    //converting Vectors2 inputs from InputManager.cs to Vector3 variables for ingame movement & gravity
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero; //same as new Vector(0,0,0);
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    // jump logics
    public void Jump()
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    // sprint logics
    public void Sprint()
    {
        isSprinting = !isSprinting;
        if (isSprinting)
            speed = 10;
        else
            speed = 5;
    }

    // crouch logics
    public void Crouch()
    {
        isCrouching = !isCrouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }
}
