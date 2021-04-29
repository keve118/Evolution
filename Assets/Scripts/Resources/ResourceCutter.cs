using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCutter : MonoBehaviour
{
    public GameObject woodCutter;
    public static bool woodCutterAvailable = false;
    public static bool woodCutterEquiped =false;

    public GameObject stoneCutter;
    public static bool stoneCutterAvailable = false;
    public static bool stoneCutterEquiped =false;

    public GameObject huntingTool;
    public static bool huntingToolAvailable = false;
    public static bool huntingToolEquiped = false;

    public GameObject fishingRod;
    public static bool fishingRodAvailable = false;
    public static bool fishingRodEquiped =false;
   
    public static bool anyToolEquiped=false;

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

        if (huntingToolAvailable)
            HuntCollector();

        if (fishingRodAvailable)
            FishCollector();


        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit; 

        //Origin, direction, raycasthit, length
        if(Physics.Raycast(transform.position,fwd,out hit, 10)) 
        { 
            if(hit.collider.tag=="Wood" && Input.GetMouseButton(0) && woodCutterEquiped) 
            {
                Harvest harvestScript = hit.collider.gameObject.GetComponent<Harvest>();
                FindObjectOfType<SoundManager>().Play("CutWood");
                harvestScript.health--;
            }
            if (hit.collider.tag == "Stone" && Input.GetMouseButton(0) && stoneCutterEquiped)
            {
                Harvest harvestScript = hit.collider.gameObject.GetComponent<Harvest>();
                FindObjectOfType<SoundManager>().Play("CutStone");
                harvestScript.health--;
            }
            if (hit.collider.tag == "Food" && Input.GetMouseButton(0) && huntingToolEquiped)
            {
                Harvest harvestScript = hit.collider.gameObject.GetComponent<Harvest>();
                FindObjectOfType<SoundManager>().Play("SpearAnimal");
                harvestScript.health--;
            }
            if (hit.collider.tag == "Food" && Input.GetMouseButton(0) && fishingRodEquiped)
            {
                Harvest harvestScript = hit.collider.gameObject.GetComponent<Harvest>();
                harvestScript.health--;
            }
        }
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


    public void HuntCollector() 
    {
        if (!huntingTool.activeSelf && Input.GetKeyDown(KeyCode.Alpha3) && !anyToolEquiped)
        {
            huntingToolEquiped = true;
            anyToolEquiped = true;
            huntingTool.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            huntingToolEquiped = false;
            anyToolEquiped = false;
            huntingTool.SetActive(false);
            return;
        }
    }


    public void FishCollector() 
    {
                    
       if (!fishingRod.activeSelf && Input.GetKeyDown(KeyCode.Alpha4) && !anyToolEquiped)
       {
           fishingRodEquiped = true;
            anyToolEquiped = true;
            fishingRod.SetActive(true);

       }
       else if (Input.GetKeyDown(KeyCode.Alpha4))
       {
           fishingRodEquiped = false;
            anyToolEquiped = false;
            fishingRod.SetActive(false);
            return;
       }
    }
}
