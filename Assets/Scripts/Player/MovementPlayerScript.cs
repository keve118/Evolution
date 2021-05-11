using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerControls;

public class MovementPlayerScript : MonoBehaviour
{
    private PlayerControls playerControls; //Holds an auto generated class from the Input System
    private InputAction directionalMovement;
    [SerializeField]private Camera mainFpsCamera; 

    private Vector2 Direction { get; set; }


    public float walkSpeed, runSpeed;
    public float jumpHeight;
    public float gravity = -9.18f;

    [SerializeField] bool isGrounded;

    private CharacterController controller;
    private Vector3 playerVelocity;
    public float currentSpeed;

    AudioSource audioSource;
    bool isMoving = false;

    void Awake()
    {
        playerControls = new PlayerControls();
        directionalMovement = playerControls.Gameplay.Movement;
        directionalMovement.performed += OnMovement; //What happens when the control is used
        directionalMovement.canceled += OnMovement; //What happens when tontrol is not used any more
    }

    public void OnMovement(InputAction.CallbackContext context) // Listens to the movment of the controls
    {
        Direction = context.ReadValue<Vector2>();
    }

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() // Input System helper
    {
        directionalMovement.Enable();
    }

    private void OnDisable() // Input System helper
    {
        directionalMovement.Disable();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        Vector3 moveDirection = transform.right * (Direction.x * 0.75f) + (transform.forward * Direction.y);
        controller.Move(moveDirection * Time.deltaTime * currentSpeed);

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            currentSpeed = runSpeed;
            isMoving = true;

            CheckStamina();
                
        }
        else if (isGrounded)
        {
            currentSpeed = walkSpeed;
            isMoving = true;
        }

        if (isGrounded)
            Jump();

        if(isMoving)
            FootstepsSound();

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
    }

    void FootstepsSound()
    {
        if (controller.velocity.x != 0)
            isMoving = true;
        else
            isMoving = false;

        if (isMoving)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
            audioSource.Stop();
    }

    void CheckStamina()
    {
        float amountOfStaminaToUse = 0.1f;
        //if staminabar is 0 (empty) you can't run
        if (StaminaBar.instance.currentStamina - amountOfStaminaToUse <= 0)
            currentSpeed = walkSpeed;

        //can only use staminabar when player is moving
        if (controller.velocity.x != 0)
            StaminaBar.instance.UseStamina(amountOfStaminaToUse);
    }
}

