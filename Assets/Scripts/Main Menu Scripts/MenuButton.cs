using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{

    public MenuButtonHandler MainMenuButtonHandler { get; set; }

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
        if (previousMousePosition != Input.mousePosition)
        {
            isMouseInputDevice = true;

        }

        if (isMouseInputDevice)
        {
            if (isMouseOver)
            {
                animator.SetBool("selected", true);
                
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
            else
            {
                animator.SetBool("selected", false);
            }

            if (!isPressedByMouse)
            {
                animator.SetBool("pressed", false);
            }
        }


        if (Input.GetAxis("Vertical") != 0 && previousMousePosition == Input.mousePosition)
        {
            isMouseInputDevice = false;
        } 

        if (!isMouseInputDevice)
        {
            KeyBoardObjectInteraction();
        }

        previousMousePosition = Input.mousePosition;
    }

    private void KeyBoardObjectInteraction()
    {
        if (MainMenuButtonHandler.index == slotInArray)
        {
            animator.SetBool("selected", true);

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
        else
        {
            animator.SetBool("selected", false);
        }
    }
}
