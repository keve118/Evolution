using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitching : MonoBehaviour
{
    public int selectedTool = 0;

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
    private GameObject activeObject;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        IsAxeEquiped();
        IsSpearEquiped();
        IsPickAxeEquiped();
        InputManager();

        int previousSelectedTool = selectedTool;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedTool >= transform.childCount - 1)
                selectedTool = 0;
            else
                selectedTool++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
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
    }

    void InputManager()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            selectedTool = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            selectedTool = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            selectedTool = 2;
    }

    void SelectTool()
    {
        int i = 0;
        foreach (Transform tool in transform)
        {
            if (i == selectedTool)
            {
                Debug.Log("Selected Tool is:" + selectedTool);
                //tool.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("Setting Previous tool to false");
                //tool.gameObject.SetActive(false);
            }
            i++;
        }
    }



    void IsAxeEquiped()
    {
        if (selectedTool == 0 && woodCutterAvailable)
        {
            woodCutterEquiped = true;
            woodCutter.SetActive(true);

            Debug.Log("WoodCutter Enabled:" + woodCutterEquiped);
        }
        else
        {
            woodCutter.SetActive(false);
            woodCutterEquiped = false;
            Debug.Log("WoodCutter Enabled:" + woodCutterEquiped);
        }
    }
    void IsSpearEquiped()
    {
        if (selectedTool == 1 && huntingToolAvailable)
        {
            huntingToolEquiped = true;
            huntingTool.SetActive(true);
        }
        else
        {
            huntingTool.SetActive(false);
            huntingToolEquiped = false;
        }
    }
    void IsPickAxeEquiped()
    {
        if (selectedTool == 2 && stoneCutterAvailable)
        {
            stoneCutterEquiped = true;
            stoneCutter.SetActive(true);
        }
        else
        {
            stoneCutterEquiped = false;
            stoneCutter.SetActive(false);
        }
    }
}
