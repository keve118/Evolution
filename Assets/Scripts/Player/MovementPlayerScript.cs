using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerControls;

public class MovementPlayerScript : MonoBehaviour, IGameplayActions
{
    private PlayerControls playerControls; //Holds an auto generated class from the Input System
    [SerializeField]private Camera mainFpsCamera; 

    private Vector2 Direction { get; set; }
    

    #region OLD LOGIC

    public float walkSpeed, runSpeed;
    public float jumpHeight;
    public float gravity = -9.18f;

    [SerializeField] bool isGrounded;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private float currentSpeed;

    AudioSource audioSource;
    bool isMoving = false;

    #endregion OLD LOGIC

    void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Gameplay.SetCallbacks(this);
    }

    public void OnMovement(InputAction.CallbackContext context) // Player Controller IGameplayActions interface implementation
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
        playerControls.Enable();
    }

    private void OnDisable() // Input System helper
    {
        playerControls.Disable();
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
<<<<<<< Updated upstream
=======

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

    public void OnLook(InputAction.CallbackContext context)
    {
        Debug.Log("Looking AF");
    }
>>>>>>> Stashed changes
}

