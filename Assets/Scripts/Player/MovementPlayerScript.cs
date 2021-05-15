<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerScript : MonoBehaviour
{
=======
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayerScript : MonoBehaviour
{
    private Vector2 Direction { get; set; }

>>>>>>> Stashed changes
    public float walkSpeed, runSpeed;
    public float jumpHeight;
    public float gravity = -9.18f;
    public float currentSpeed;

    [SerializeField] private bool isGrounded;
    [SerializeField] private Camera mainFpsCamera;

    private PlayerControls playerControls; //Holds an auto generated class from the Input System
    private InputAction directionalMovement;
    private InputAction jump;
    private CharacterController controller;
    private AudioSource audioSource;
    private Vector3 playerVelocity;
    private bool isMoving = false;
    private bool isJump;

<<<<<<< Updated upstream
    // Start is called before the first frame update
=======
    void Awake()
    {
        playerControls = new PlayerControls();

        directionalMovement = playerControls.Gameplay.Movement;
        directionalMovement.performed += OnMovement; //When input call this method to read value
        directionalMovement.canceled += OnMovement;

        jump = playerControls.Gameplay.Jump;
        jump.performed += context => isJump = true; //Overridning returntype float setting it to bool
        jump.canceled += context => isJump = false;
    }

    private void OnEnable() => playerControls.Gameplay.Enable(); // When object enabled, actionmap is enabled

    private void OnDisable() => playerControls.Gameplay.Disable();

    public void OnMovement(InputAction.CallbackContext context) // Listens to the movment of the controls
    {
        Direction = context.ReadValue<Vector2>();
    }

>>>>>>> Stashed changes
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
        audioSource = GetComponent<AudioSource>();
    }

<<<<<<< Updated upstream
    // Update is called once per frame
=======
>>>>>>> Stashed changes
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;

        }


        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = transform.right * (x * 0.75f) + transform.forward * z;

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

        if (isMoving)
            FootstepsSound();

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


    void Jump()
    {
        if (isJump)
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

