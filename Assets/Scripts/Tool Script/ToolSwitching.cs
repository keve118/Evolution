using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToolSwitching : MonoBehaviour
{
    [Header("WoodCutter Settings")]
    public GameObject woodCutter;
    public static bool woodCutterAvailable;
    public static bool woodCutterEquiped;

    [Header("StoneCutter Settings")]
    public GameObject stoneCutter;
    public static bool stoneCutterAvailable;
    public static bool stoneCutterEquiped;

    [Header("HuntingTool Settings")]
    public GameObject huntingTool;
    public static bool huntingToolAvailable;
    public static bool huntingToolEquiped;

    [Header("General Settings")]
    public static bool anyToolEquiped = false;
    private Ray ray;
    public GameObject rayObject;
    public int selectedTool = 0;

    public enum ToolState
    {
        WoodAxe,
        StoneAxe,
        Spear,
        Empty
    }

    public ToolState currentState;

    private PlayerControls playerControls;
    private InputAction selectTool;
    private float selectToolvalue;
    private bool isKeyDown;

    private void Awake()
    {
        playerControls = new PlayerControls();

        selectTool = playerControls.Gameplay.SelectTool;
        selectTool.performed += OnSelectTool;
        selectTool.canceled += OnSelectTool;
    }

    private void OnEnable() => playerControls.Enable();
    private void OnDisable() => playerControls.Disable();

    private void OnSelectTool(InputAction.CallbackContext context)
    {
        selectToolvalue = context.ReadValue<float>();
    }

    void Start()
    {
        huntingToolEquiped = true;
        woodCutterEquiped = true;
        stoneCutterEquiped = true;
        huntingToolAvailable = false;
        woodCutterAvailable = false;
        stoneCutterAvailable = false;     
        SelectTool();
    }

    void Update()
    {
        int previousSelectedTool = selectedTool;
        if (selectToolvalue > 0f)
        {
            if (selectedTool >= transform.childCount - 1)
                selectedTool = 0;
            else
                selectedTool++;
        }
        if (selectToolvalue < 0f)
        {
            if (selectedTool <= transform.childCount - 1)
                selectedTool = transform.childCount - 1;
            else
                selectedTool--;
        }
        if (previousSelectedTool != selectedTool)
        {
            SelectTool();
        }
        InputManager();
        SelectTool();
        Switcher();
    }

    void InputManager()
    {
        if (Keyboard.current.digit0Key.wasPressedThisFrame)
            selectedTool = 0;
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            selectedTool = 1;
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            selectedTool = 2;
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            selectedTool = 3;
    }

    void SelectTool()
    {
        int i = 0;
        foreach (Transform tool in transform)
        {
            if (selectedTool == 0)
                currentState = ToolState.Empty;
            if (selectedTool == 1 && woodCutterAvailable)
                currentState = ToolState.WoodAxe;
            if (selectedTool == 2 && stoneCutterAvailable)
                currentState = ToolState.StoneAxe;
            if (selectedTool == 3 && huntingToolAvailable)
                currentState = ToolState.Spear;
            i++;
        }
    }

    void Switcher() 
    {
        switch (currentState)
        {
            case ToolState.Empty:
                {
                    woodCutter.SetActive(false);
                    stoneCutter.SetActive(false);
                    huntingTool.SetActive(false);
                    woodCutterEquiped = false;
                    stoneCutterEquiped = false;
                    huntingToolEquiped = false;
                    break;
                }
            case ToolState.WoodAxe:
                {
                    woodCutter.SetActive(true);
                    stoneCutter.SetActive(false);
                    huntingTool.SetActive(false);
                    woodCutterEquiped = true;
                    stoneCutterEquiped = false;
                    huntingToolEquiped = false;
                    break;
                }
            case ToolState.StoneAxe:
                {
                    woodCutter.SetActive(false);
                    stoneCutter.SetActive(true);
                    huntingTool.SetActive(false);
                    woodCutterEquiped = false;
                    stoneCutterEquiped = true;
                    huntingToolEquiped = false;
                    break;
                }
            case ToolState.Spear:
                {
                    woodCutter.SetActive(false);
                    stoneCutter.SetActive(false);
                    huntingTool.SetActive(true);
                    woodCutterEquiped = false;
                    stoneCutterEquiped = false;
                    huntingToolEquiped = true;
                    break;
                }
        }
    }
}
