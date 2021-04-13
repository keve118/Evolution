using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCutter : MonoBehaviour
{
    public GameObject woodCutter;
    public static bool woodCutterAvailable = false;
    private bool woodCutterEquiped;

    public GameObject stoneCutter;
    public static bool stoneCutterAvailable = true;
    private bool stoneCutterEquiped;

    public GameObject huntingTool;
    public static bool huntingToolAvailable = true;
    private bool huntingToolEquiped;

    public GameObject fishingRod;
    public static bool fishingRodAvailable = true;
    private bool fishingRodEquiped;


    private bool anyToolEquiped=false;

    private void Update()
    {

        if (woodCutterAvailable)
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

            }           
        }
        //if (stoneCutterAvailable)
        //{
        //    if (!stoneCutter.activeSelf && Input.GetKeyDown(KeyCode.Alpha2) && !anyToolEquiped )
        //    {
        //        stoneCutterEquiped = true;
        //        anyToolEquiped = true;
        //        stoneCutter.SetActive(true);
        //    }
        //    else if (Input.GetKeyDown(KeyCode.Alpha2))
        //    {
        //        stoneCutterEquiped = false;
        //        stoneCutter.SetActive(false);
        //    }
        //}
        //if (huntingToolAvailable)
        //{
        //    if (!huntingTool.activeSelf && Input.GetKeyDown(KeyCode.Alpha3) && !anyToolEquiped)
        //    {
        //        huntingToolEquiped = true;
        //        huntingTool.SetActive(true);

        //    }
        //    else if (Input.GetKeyDown(KeyCode.Alpha3))
        //    {
        //        huntingToolEquiped = false;
        //        huntingTool.SetActive(false);

        //    }
        //}
        //if (fishingRodAvailable)
        //{
        //    if (!fishingRod.activeSelf && Input.GetKeyDown(KeyCode.Alpha4) && !anyToolEquiped)
        //    {
        //        fishingRodEquiped = true;
        //        fishingRod.SetActive(true);

        //    }
        //    else if (Input.GetKeyDown(KeyCode.Alpha4))
        //    {
        //        fishingRodEquiped = false;
        //        fishingRod.SetActive(false);

        //    }
        //}


        //Raycast
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, 10))
        {
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
        }
    }
}
