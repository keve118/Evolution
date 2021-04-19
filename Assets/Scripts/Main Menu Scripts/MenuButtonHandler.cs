using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
///  Class Responsible for handeling the menu buttons in the custom textbutton menu
/// </summary>
[RequireComponent(typeof(MenuDelegateCollection))]
public class MenuButtonHandler : MonoBehaviour
{

    public AudioSource audioSource;
    public Text[] textButtons;

    [SerializeField] private bool isKeyDown;
    [SerializeField] private AnimatorAudioHelper animatorAudioHelper;

    [HideInInspector] public bool isMouseInputDevice;
    [HideInInspector] public int index;

    private int indexMax;
    private Vector3 previousMousePosition;
    private const string vertical = "Vertical";

    void Start()
    {
        indexMax = textButtons.Length - 1;
        audioSource = GetComponent<AudioSource>();

        //Links textbuttons and make them aware of their array index
        for (int i = 0; i < textButtons.Length; i++)
        {
            textButtons[i].GetComponent<MenuButton>().buttonIndex = i;
        }

        previousMousePosition = Input.mousePosition;
    }

    //Mouse State Fetching Methods

    void Update()
    {
        if (previousMousePosition != Input.mousePosition)
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
            previousMousePosition = Input.mousePosition;
            isMouseInputDevice = false;
            return;
        }

        if (Input.GetAxis(vertical) != 0)
        {

            if (!isKeyDown)
            {
                if (Input.GetAxis(vertical) < 0)
                {
                    HandleUpwardIncrement();
                }
                else if (Input.GetAxis(vertical) > 0)
                {
                    HandleDownwardIncrement();

                }
                isKeyDown = true;
            }
        }
        else
        {
            isKeyDown = false;
        }

        previousMousePosition = Input.mousePosition;

        //Counts down and makes menu loop on itself when it reaches below min index
        void HandleDownwardIncrement()
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
        void HandleUpwardIncrement()
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
}