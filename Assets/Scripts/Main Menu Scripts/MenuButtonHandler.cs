using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuButtonHandler : MonoBehaviour
{
    public bool IsMouseOverWord { get; set; }

    private bool isAnimationStarted;

    public bool IsAnimationStarted
    {
        get { return isAnimationStarted; }
        
        set { if (!isAnimationStarted) isAnimationStarted = value; }
    }


    [HideInInspector] public int index;

    private int indexMax;
    
    private const string vertical = "Vertical";
    
    [SerializeField] public Text[] textButtons;
    [SerializeField] private bool keyDown;
    [SerializeField] private AnimatorAudioHelper animatorAudioHelper;
    [SerializeField] public AudioSource audioSource;

    void Start()
    {
        indexMax = textButtons.Length - 1;
        audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < textButtons.Length; i++)
        {
            textButtons[i].GetComponent<MenuButton>().slotInArray = i;
            textButtons[i].GetComponent<MenuButton>().MainMenuButtonHandler = this;
        }
    }

    void Update()
    {
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
