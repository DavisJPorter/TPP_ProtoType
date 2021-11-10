using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDATE
{


public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float walkSpeed = 3f;
    public float sprintSpeed = 10f;
    public float crouchSpeed = 1f;
    public float currentSpeed;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float playerStamina = 100.0f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool sprintAble = true;

    private bool isCrouching;
    private Vector3 originalCenter;
    private float originalHeight;
    private float originalMoveSpeed;
    private int staminaDrain = 10;
    private float maxStamina = 100.0f;
    private float minStamina = 0.0f;
    private float staminaRegen = 100.0f;

    void Start()
    {
        transform.tag = "Player"; 
        controller = GetComponent<CharacterController>();
        originalCenter = controller.center;
        originalHeight = controller.height;
        originalMoveSpeed = walkSpeed;
    }
    void Update()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            controller.height = 1f;
            controller.center = new Vector3(0f, -0.5f, 0f);
            walkSpeed = crouchSpeed;
            isCrouching = true;
        }

        if (!Input.GetButton("Crouch") && isCrouching)
        {
                walkSpeed = crouchSpeed;
                controller.height = originalHeight;
            controller.center = originalCenter;
            isCrouching = false;
            crouchSpeed = originalMoveSpeed;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * walkSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetButtonDown("Run") && sprintAble)
        {
            walkSpeed = sprintSpeed;
            playerStamina = maxStamina - staminaDrain;
        }
        if (playerStamina > maxStamina)
            {
                playerStamina = maxStamina;
            }
        if (playerStamina < minStamina)
            {
                playerStamina = minStamina;
                sprintAble = false;
                walkSpeed = 3f;
            }
        else if (Input.GetButtonUp("Run"))
        {
            walkSpeed = 3f;
            playerStamina += staminaRegen;
        }
        if (staminaRegen == maxStamina)
            {
                sprintAble = true;
            }




        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        controller.Move(move * currentSpeed * Time.deltaTime);
    }
}
}
