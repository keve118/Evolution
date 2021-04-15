using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  Class Responsible for handeling the menu buttons in the custom textbutton menu
/// </summary>

public class MenuButtonHandler : MonoBehaviour
{
    public bool IsMouseOverWord { get; set; }

    private bool isAnimationStarted;

    public bool IsAnimationStarted
    {
        get { return isAnimationStarted; }

        set { if (!isAnimationStarted) isAnimationStarted = value; }
    }

    public AudioSource audioSource;
    public Text[] textButtons;

    [SerializeField] private bool keyDown;
    [SerializeField] private AnimatorAudioHelper animatorAudioHelper;
   

    [HideInInspector] public int index;
    
    private const string vertical = "Vertical";
    private int indexMax;

    void Start()
    {
        indexMax = textButtons.Length - 1;
        audioSource = GetComponent<AudioSource>();

        //Links textbuttons and make them aware of their array index
        for (int i = 0; i < textButtons.Length; i++)
        {
            textButtons[i].GetComponent<MenuButton>().slotInArray = i;
            textButtons[i].GetComponent<MenuButton>().MainMenuButtonHandler = this;
        }
    }

    void Update()
    {
        //Skips loop if the mouse is the input device
        if (IsMouseOverWord)
        {
            return;
        }

        if (Input.GetAxis(vertical) != 0)
        {
  
            if (!keyDown)
            {
                if (Input.GetAxis(vertical) < 0)
                {
                    HandleUpwardIncrement();
                }
                else if (Input.GetAxis(vertical) > 0)
                {
                    HandleDownwardIncrement();

                }
                keyDown = true;
            }
        }
        else
        {
            keyDown = false;
        }
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
