using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

/// <summary>
/// Class that defines the custom text menu button and handles input response
/// </summary>
public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Assign delegate function to the button")]
    public UnityEvent buttonEvent;
    public int buttonIndex;
    public Animator animator;

    [HideInInspector] public bool isMouseOver;

    [SerializeField] private AnimatorAudioHelper animatorAudioHelper;
    private MenuButtonHandler menuButtonHandler;

    private PlayerControls playerControls;
    private InputAction selectAction;
    private bool isKeyDown;
    private bool isSelecting;

    //Event implementation for reacting to mouse input 
    public void OnPointerEnter(PointerEventData eventData) //Consumed in handler
    {
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData) //Consumed in handler
    {
        isMouseOver = false;
    }
   
    private void Awake()
    {
        menuButtonHandler = GetComponentInParent<MenuButtonHandler>();
        playerControls = new PlayerControls();

        selectAction = playerControls.Menu.Select;
        selectAction.performed += context => isSelecting = true;
        selectAction.canceled += contex => isSelecting = false;
    }

    private void OnEnable() => playerControls.Menu.Enable();

    private void OnDisable() => playerControls.Menu.Disable();

    void Update()
    {
        //Reads interaction with button to determine boolean state of the animator
        //Takes mouse, keyboard and hand controller 

        if (menuButtonHandler.index == this.buttonIndex)
        {
            if (!isKeyDown)
            {
                animator.SetBool("selected", true);
                if (isSelecting)
                {
                    animator.SetBool("pressed", true);
                }
                else if (animator.GetBool("pressed"))
                {
                    buttonEvent.Invoke();
                    animator.SetBool("pressed", false);
                    animatorAudioHelper.disableOnce = true;
                }
                
                isKeyDown = true;
            }
            else
            {
                isKeyDown = false;
            }
        }
        else
        {
            animator.SetBool("selected", false);
        }
    }
}

