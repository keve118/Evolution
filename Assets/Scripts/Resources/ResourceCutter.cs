using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCutter : MonoBehaviour
{
    public GameObject woodCutter;
    public static bool woodCutterAvailable = false;
<<<<<<< Updated upstream:Assets/Scripts/ResourceCutter.cs
    private bool woodCutterEquiped;

    public GameObject stoneCutter;
    public static bool stoneCutterAvailable = false;
    private bool stoneCutterEquiped;

    public GameObject huntingTool;
    public static bool huntingToolAvailable = true;
    private bool huntingToolEquiped;

    public GameObject fishingRod;
    public static bool fishingRodAvailable = true;
    private bool fishingRodEquiped;

=======
    public static bool woodCutterEquiped=false;

    public GameObject stoneCutter;
    public static bool stoneCutterAvailable = false;
    public static bool stoneCutterEquiped=false;

    public GameObject huntingTool;
    public static bool huntingToolAvailable = true;
    public static bool huntingToolEquiped=false;

    public GameObject fishingRod;
    public static bool fishingRodAvailable = true;
    public static bool fishingRodEquiped=false;
>>>>>>> Stashed changes:Assets/Scripts/Resources/ResourceCutter.cs

    private bool anyToolEquiped=false;


    private void Update()
    {
        while (woodCutterEquiped || stoneCutterEquiped || fishingRodEquiped || huntingToolEquiped)
        {
            anyToolEquiped = true;

            if (!woodCutterEquiped || !stoneCutterEquiped || !fishingRodEquiped || !huntingToolEquiped)
                break;
        }
                
        if (woodCutterAvailable)
            WoodCutter();

         if (stoneCutterAvailable)
            StoneCutter();

       //if (huntingToolAvailable || fishingRodAvailable)
       //     FoodCollector();
    }

    public void WoodCutter() 
    {
        if (!woodCutter.activeSelf && Input.GetKeyDown(KeyCode.Alpha1) && !anyToolEquiped)
        {
            woodCutterEquiped = true;
            anyToolEquiped = true;
            woodCutter.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            woodCutterEquiped = false;
            anyToolEquiped = false;
            woodCutter.SetActive(false);
            return;
        }
    }
    public void StoneCutter() 
    {
        if (!stoneCutter.activeSelf && Input.GetKeyDown(KeyCode.Alpha2) && !anyToolEquiped)
        {
<<<<<<< Updated upstream:Assets/Scripts/ResourceCutter.cs
            if (hit.collider.tag == "Wood" && Input.GetMouseButton(0) && woodCutterEquiped == true)
            {
                CutAble cutScript = hit.collider.gameObject.GetComponent<CutAble>();
                cutScript.resourceHealth--;
            }
            if (hit.collider.tag == "Stone" && Input.GetMouseButton(0) && stoneCutterEquiped == true)
            {
                CutAble cutScript = hit.collider.gameObject.GetComponent<CutAble>();
                cutScript.resourceHealth--;
            }
            if (hit.collider.tag == "Food" && Input.GetMouseButton(0) && huntingToolEquiped == true)
            {
                CutAble cutScript = hit.collider.gameObject.GetComponent<CutAble>();
                cutScript.resourceHealth--;
            }
            if (hit.collider.tag == "Food" && Input.GetMouseButton(0) && fishingRodEquiped == true)
            {
                CutAble cutScript = hit.collider.gameObject.GetComponent<CutAble>();
                cutScript.resourceHealth--;
            }
=======
            stoneCutterEquiped = true;
            anyToolEquiped = true;
            stoneCutter.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            stoneCutterEquiped = false;
            anyToolEquiped = false;
            stoneCutter.SetActive(false);
            return;
        }
    }

    public void FoodCollector() 
    {
        if (!huntingTool.activeSelf && Input.GetKeyDown(KeyCode.Alpha3) && !anyToolEquiped)
        {
            huntingToolEquiped = true;
            huntingTool.SetActive(true);

>>>>>>> Stashed changes:Assets/Scripts/Resources/ResourceCutter.cs
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            huntingToolEquiped = false;
            huntingTool.SetActive(false);

        }              
       else if (!fishingRod.activeSelf && Input.GetKeyDown(KeyCode.Alpha4) && !anyToolEquiped)
       {
           fishingRodEquiped = true;
           fishingRod.SetActive(true);

       }
       else if (Input.GetKeyDown(KeyCode.Alpha4))
       {
           fishingRodEquiped = false;
           fishingRod.SetActive(false);

       }
    }












}
