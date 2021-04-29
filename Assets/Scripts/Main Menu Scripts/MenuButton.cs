using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// Class that defines the custom text menu button and handles input response
/// </summary>
public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Assign delegate function to the button")]
    
    public UnityEvent buttonEvent;
    public int buttonIndex;
   
    [HideInInspector] public bool isMouseOver;
    
    [SerializeField] private Animator animator;
    [SerializeField] private AnimatorAudioHelper animatorAudioHelper;
    
    private MenuButtonHandler menuButtonHandler;
    private bool isMouseKeyDown;
    private bool isKeyDown;

    #region Event implementation for reacting to mouse input 
    public void OnPointerClick(PointerEventData eventData)
    {
        isMouseKeyDown = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }
    #endregion

    private void Awake()
    {
        menuButtonHandler = GetComponentInParent<MenuButtonHandler>();
    }

    void Update()
    {
        //Reads interaction with button to determine boolean state of the animator
        //Takes mouse, keyboard and hand controller 


        if (menuButtonHandler.index == this.buttonIndex)
        {
            if (!isKeyDown || Input.GetButtonDown("Fire1"))
            {
                animator.SetBool("selected", true);
                if (Input.GetAxisRaw("Submit") == 1 || Input.GetButtonDown("Fire1"))
                {
                    Debug.Log("Here be Mice");
                    animator.SetBool("pressed", true);

                }
                else if (animator.GetBool("pressed"))
                {
                    animator.SetBool("pressed", false);
                    animatorAudioHelper.disableOnce = true;
                    buttonEvent.Invoke();
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

