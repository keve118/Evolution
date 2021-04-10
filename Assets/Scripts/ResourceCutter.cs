using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCutter : MonoBehaviour
{
    public GameObject woodCutter;
    private bool woodCutterAvailable;
    private bool woodCutterEquiped;

    public GameObject stoneCutter;
    private bool stoneCutterAvailable;
    private bool stoneCutterEquiped;

    public GameObject huntingTool;
    private bool huntingToolAvailable;
    private bool huntingToolEquiped;

    public GameObject fishingRod;
    private bool fishingRodAvailable;
    private bool fishingRodEquiped;

    private void Update()
    {
        if (woodCutterAvailable) 
        {
            if (!woodCutter.activeSelf && Input.GetKeyDown(KeyCode.Alpha1))
            {
                woodCutterEquiped = true;
                woodCutter.SetActive(true);

            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                woodCutterEquiped = false;
                woodCutter.SetActive(false);

            }
        }

        if (stoneCutterAvailable)
        {
            if (!stoneCutter.activeSelf && Input.GetKeyDown(KeyCode.Alpha2))
            {
                stoneCutterEquiped = true;
                stoneCutter.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                stoneCutterEquiped = false;
                stoneCutter.SetActive(false);
            }
        }

        if (huntingToolAvailable)
        {
            if (!huntingTool.activeSelf && Input.GetKeyDown(KeyCode.Alpha3))
            {
                huntingToolEquiped = true;
                huntingTool.SetActive(true);

            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                huntingToolEquiped = false;
                huntingTool.SetActive(false);

            }
        }

        if (fishingRodAvailable)
        {
            if (!fishingRod.activeSelf && Input.GetKeyDown(KeyCode.Alpha1))
            {
                fishingRodEquiped = true;
                fishingRod.SetActive(true);

            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                fishingRodEquiped = false;
                fishingRod.SetActive(false);

            }
        }


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










        }
    }
}
