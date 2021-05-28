using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuilderUI : MonoBehaviour
{

    public GameObject builderUI;
    private PlayerControls playerControls;
    private InputAction openBuildingUI;
    private bool isOpenButtonPressed;

    private void Awake()
    {
        playerControls = new PlayerControls();
        openBuildingUI = playerControls.Gameplay.BuildingMenu;
        openBuildingUI.performed += context => isOpenButtonPressed = true;
        openBuildingUI.canceled += context => isOpenButtonPressed = false;
    }

    private void OnEnable() => playerControls.Enable();
    private void OnDisable() => playerControls.Disable();

    public void Update()
    {
        if (!builderUI.activeSelf && isOpenButtonPressed) 
        {
            builderUI.SetActive(true);       
        }
        else if (isOpenButtonPressed)
        {
            builderUI.SetActive(false);
            return;
        }
    }
}
