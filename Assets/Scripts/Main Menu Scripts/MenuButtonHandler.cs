using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
///  Class Responsible for handeling the menu buttons in the custom textbutton menu
/// </summary>
[RequireComponent(typeof(MenuDelegateCollection))]
public class MenuButtonHandler : MonoBehaviour
{

    public AudioSource audioSource;
    public Text[] textButtons;

    [HideInInspector] public bool isMouseInputDevice;
    [HideInInspector] public int index;

    [SerializeField] private bool isKeyDown;
    [SerializeField] private AnimatorAudioHelper animatorAudioHelper;


    private PlayerControls playerControls;
    private InputAction menuMovment;
    private InputAction menuSelect;
    private Vector2 previousMousePosition;
    private Vector2 currentMousePosition;
    private int indexMax;
    private int verticalInput;
    private InputAction mouseCoordinates;

    private void Awake()
    {
        playerControls = new PlayerControls();

        menuMovment = playerControls.Menu.Move;
        menuMovment.performed += OnMenuMove;
        menuMovment.canceled += OnMenuMove;

        mouseCoordinates = playerControls.Menu.MouseCoordinates;
        mouseCoordinates.performed += context => currentMousePosition = context.ReadValue<Vector2>();
        mouseCoordinates.canceled += context => currentMousePosition = context.ReadValue<Vector2>();
    }

    private void OnMenuMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>().y;

        //Turns float to int from gamepad feed
        if (value > 0)
        {
            verticalInput = value > 0.5f ? 1 : 0;

        }
        else if (value < 0)
        {
            verticalInput = value < -0.5f ? -1 : 0;
        }
        else
        {
            verticalInput = 0;
        }
    }

    private void OnEnable() => playerControls.Menu.Enable();

    private void OnDisable() => playerControls.Menu.Disable();

    void Start()
    {
        indexMax = textButtons.Length - 1;
        audioSource = GetComponent<AudioSource>();

        //Links textbuttons and make them aware of their array index
        for (int i = 0; i < textButtons.Length; i++)
        {
            textButtons[i].GetComponent<MenuButton>().buttonIndex = i;
        }

        previousMousePosition = currentMousePosition;
    }

    //Mouse State Fetching Methods

    void Update()
    {
        if (previousMousePosition != currentMousePosition)
        {
            isMouseInputDevice = true;
        }

        //If mouse is use block selects the button
        if (isMouseInputDevice)
        {
            for (int i = 0; i < textButtons.Length; i++)
            {
                if (textButtons[i].gameObject.GetComponent<MenuButton>().isMouseOver)
                {
                    index = textButtons[i].gameObject.GetComponent<MenuButton>().buttonIndex;
                }
            }
            previousMousePosition = currentMousePosition;
            isMouseInputDevice = false;
            return;
        }

        if (verticalInput != 0)
        {
            if (!isKeyDown)
            {
                if (verticalInput > 0.5)
                {
                    HandleDownwardIncrement();
                }
                else if (verticalInput < -0.5)
                {
                    HandleUpwardIncrement();
                }
                isKeyDown = true;
            }
        }

        else
        {
            isKeyDown = false;
        }

        previousMousePosition = currentMousePosition;

    }

    //Counts down and makes menu loop on itself when it reaches below min index

    private void HandleDownwardIncrement()
    {
        if (index > 0)
        {
            index--;
        }
        else
        {
            index = indexMax;
        }
    }

    //Counts up and makes menu loop on itself when it reaches above max index
    private void HandleUpwardIncrement()
    {
        if (index < indexMax)
        {
            index++;
        }
        else
        {
            index = 0;
        }
    }
}