using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayerScript : MonoBehaviour
{
    private Vector2 Direction { get; set; }

    public float walkSpeed, runSpeed;
    public float jumpHeight;
    public float gravity = -9.18f;
    public float currentSpeed;

    [SerializeField] private bool isGrounded;
    [SerializeField] private Camera mainFpsCamera;

    private PlayerControls playerControls; //Holds an auto generated class from the Input System
    private InputAction directionalMovement;
    private InputAction jump;
    private InputAction run;
    private CharacterController controller;
    private AudioSource audioSource;
    private Vector3 playerVelocity;
    private bool isMoving = false;
    private bool isJump;
    private bool isRun;

    void Awake()
    {
        playerControls = new PlayerControls();

        directionalMovement = playerControls.Gameplay.Movement;
        directionalMovement.performed += OnMovement; //When input call this method to read value
        directionalMovement.canceled += OnMovement;

        jump = playerControls.Gameplay.Jump;
        jump.performed += context => isJump = true; //Overridning returntype float setting it to bool
        jump.canceled += context => isJump = false;

        run = playerControls.Gameplay.Run;
        run.performed += context => isRun = true;
        run.canceled += context => isRun = false;
        
    }

    private void OnEnable() => playerControls.Gameplay.Enable(); // When object enabled, actionmap is enabled

    private void OnDisable() => playerControls.Gameplay.Disable();

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

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        Vector3 moveDirection = transform.right * (Direction.x * 0.75f) + (transform.forward * Direction.y);
        controller.Move(moveDirection * Time.deltaTime * currentSpeed);

        if (isRun && isGrounded)
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

        if(playerVelocity.y < -50)
        {
            PlayerDies();
            playerVelocity.y = -50;
        }
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

    void PlayerDies()
    {
        FindObjectOfType<GameStateManager>().EndGame();
    }
}

