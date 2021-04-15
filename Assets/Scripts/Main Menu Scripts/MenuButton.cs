using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Class that defines the custom text menu button and handles input response
/// </summary>
public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{

    public MenuButtonHandler MainMenuButtonHandler { get; set; }


    private bool isFirstUpdate = true;
    private bool isInitialMouseOverCheck = true;

    [SerializeField] private Animator animator;
    [SerializeField] private AnimatorAudioHelper animatorAudioHelper;


    [HideInInspector] public int slotInArray;
    [HideInInspector] public bool isLastSelectionByMouse = true;

    private Vector3 previousMousePosition;
    private bool isMouseOver;
    private bool isPressedByMouse;
    private bool isMouseInputDevice;
    private bool isDeviceKeyPressed;

    private void Awake()
    {

    }

    private void Start()
    {
        animatorAudioHelper = gameObject.GetComponentInParent<AnimatorAudioHelper>();
        previousMousePosition = Input.mousePosition;
    }

    #region Mouse State Fetching Methods
    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressedByMouse = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressedByMouse = false;
    }
    #endregion

    void Update()
    {
        //Decides what menu item is highlighted on start
        if (isFirstUpdate)
        {
            bool state = (slotInArray == 0) ? true : false;
            animator.SetBool("onStart", state);
            isFirstUpdate = false;
        }

        //The highlighted item on start klick check
        if (animator.GetBool("onStart"))
        {
            ReadInputDevicePressAction();
        }

        if (previousMousePosition != Input.mousePosition)
        {
            isMouseInputDevice = true;

        }

        //Button select with mouse 
        if (isMouseInputDevice)
        {
            if (isMouseOver)
            {
                isLastSelectionByMouse = true;

                //Preserves highlight when mouse leaves the boundinbox of the text
                for (int i = 0; i < MainMenuButtonHandler.textButtons.Length; i++)
                {
                    var otherMenuObject = MainMenuButtonHandler.textButtons[i].GetComponent<MenuButton>();

                    if (slotInArray != otherMenuObject.slotInArray)
                    {
                        otherMenuObject.isLastSelectionByMouse = false; 
                    }
                }

                if (isInitialMouseOverCheck)
                {
                    SetAllOtherInstancesToDeselected();
                }

                animator.SetBool("selected", true);

                ReadMousePressAction();
            }
            else
            {
                if (!isLastSelectionByMouse)
                {
                    animator.SetBool("selected", false);
                }
            }

            if (!isPressedByMouse)
            {
                animator.SetBool("pressed", false);
            }
        }

        //Breaks mouse control and gives control to input device
        if (Input.GetAxis("Vertical") != 0 && previousMousePosition == Input.mousePosition)
        {
            isMouseInputDevice = false;

            for (int i = 0; i < MainMenuButtonHandler.textButtons.Length; i++)
            {
                if (this.slotInArray != MainMenuButtonHandler.textButtons[i].gameObject.GetComponent<MenuButton>().slotInArray)
                {
                    animator.SetBool("onStart", false);
                }
                else
                {
                    animator.SetBool("onStart", true);
                }
            }
        }

        if (!isMouseInputDevice)
        {
            InputDeviceObjectInteraction();
        }

        previousMousePosition = Input.mousePosition;
    }


    //Highlight index 0 of menubutton on start
    private void SetAllOtherInstancesToDeselected()
    {
        foreach (var item in MainMenuButtonHandler.textButtons)
        {
            if (item != this)
            {
                item.gameObject.GetComponent<Animator>().SetBool("onStart", false);
            }
        }

        isInitialMouseOverCheck = false;
    }

    //Identify available menubutton for keypress - keyboard, hand controller
    private void InputDeviceObjectInteraction()
    {
        if (MainMenuButtonHandler.index == slotInArray)
        {
            animator.SetBool("selected", true);

            ReadInputDevicePressAction();
        }
        else
        {
            animator.SetBool("selected", false);
        }
    }

    private void ReadInputDevicePressAction()
    {
        if (Input.GetAxis("Submit") == 1)
        {
            if (!isDeviceKeyPressed)
            {
                animator.SetBool("pressed", true);
                Debug.Log("Keyboard Pressed");
            }
            else if (animator.GetBool("pressed"))
            {
                animator.SetBool("pressed", false);

                animatorAudioHelper.disableOnce = true;
            }
            isDeviceKeyPressed = true;
        }
        else
        {
            isDeviceKeyPressed = false;
        }
    }

    private void ReadMousePressAction()
    {
        if (isPressedByMouse)
        {
            animator.SetBool("pressed", true);
            Debug.Log("Mouse Pressed");
        }
        else if (animator.GetBool("pressed"))
        {
            animator.SetBool("pressed", false);

            animatorAudioHelper.disableOnce = true;
        }
    }
}

