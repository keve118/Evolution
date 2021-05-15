<<<<<<< HEAD
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayerScript : MonoBehaviour
{
    private Vector2 Direction { get; set; }

=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerScript : MonoBehaviour
{
>>>>>>> parent of 99746f9 (Tool switching)
    public float walkSpeed, runSpeed;
    public float jumpHeight;
    public float gravity = -9.18f;

    [SerializeField] bool isGrounded;

    private CharacterController controller;
    private Vector3 playerVelocity;
<<<<<<< HEAD
    private bool isMoving = false;
    private bool isJump;

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
=======
    public float currentSpeed;
>>>>>>> parent of 99746f9 (Tool switching)

    AudioSource audioSource;
    bool isMoving = false;

<<<<<<< HEAD
=======
    // Start is called before the first frame update
>>>>>>> parent of 99746f9 (Tool switching)
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
        audioSource = GetComponent<AudioSource>();
    }

<<<<<<< HEAD
=======
    // Update is called once per frame
>>>>>>> parent of 99746f9 (Tool switching)
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

