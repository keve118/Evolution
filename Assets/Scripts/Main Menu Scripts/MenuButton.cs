using UnityEngine;
using UnityEngine.EventSystems;

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

    private Vector3 previousMousePosition;
    private bool isMouseOver;
    private bool isPressedByMouse;
    private bool isMouseInputDevice;

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
                if (isInitialMouseOverCheck)
                {
                    SetAllOtherInstancesToDeselected();
                }

                animator.SetBool("selected", true);

                ReadMousePressAction();
            }
            else
            {
                animator.SetBool("selected", false);
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
            animator.SetBool("onStart", true);
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
            animator.SetBool("pressed", true);
            Debug.Log("Keyboard Pressed");
        }
        else if (animator.GetBool("pressed"))
        {
            animator.SetBool("pressed", false);

            animatorAudioHelper.disableOnce = true;
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
