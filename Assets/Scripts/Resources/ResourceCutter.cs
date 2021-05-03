using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCutter : MonoBehaviour
{
    public GameObject woodCutter;
    public static bool woodCutterAvailable = false;
    public static bool woodCutterEquiped;

    public GameObject stoneCutter;
    public static bool stoneCutterAvailable = false;
    public static bool stoneCutterEquiped;

    public GameObject huntingTool;
    public static bool huntingToolAvailable = false;
    public static bool huntingToolEquiped;
   
    public static bool anyToolEquiped=false;

    private void Start()
    {
        huntingToolEquiped = false;
        woodCutterEquiped = false;
        stoneCutterEquiped = false;
    }

    private void Update()
    {
        while (woodCutterEquiped || stoneCutterEquiped || huntingToolEquiped)
        {
            anyToolEquiped = true;
            if (!woodCutterEquiped || !stoneCutterEquiped || !huntingToolEquiped)
                break;
        }

        if (woodCutterAvailable)
            EnableTool(woodCutter, KeyCode.Alpha1);            
        if (stoneCutterAvailable)
            EnableTool(stoneCutter, KeyCode.Alpha2);
        if (huntingToolAvailable)
            EnableTool(huntingTool, KeyCode.Alpha3);
    }

    private void FixedUpdate()
    {    
        Vector3 forward = transform.TransformDirection(PlayerProperties.rayCastTransform.position);
        Ray ray = new Ray(PlayerProperties.rayCastOrigin, PlayerProperties.rayCastTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10))
        {

            if (hit.collider.tag == "Wood" && Input.GetMouseButton(0) && woodCutterEquiped)
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
        }
    }

    public void EnableTool(GameObject toolObject, KeyCode activate) 
    {
        if (!toolObject.activeSelf && Input.GetKeyDown(activate) && !anyToolEquiped)
        {
            if (toolObject == woodCutter)
                woodCutterEquiped = true;
            if (toolObject == stoneCutter)
                stoneCutterEquiped = true;
            if (toolObject == huntingTool)
                huntingToolEquiped = true;
    
            anyToolEquiped = true;
            toolObject.SetActive(true);
        }
        else if (Input.GetKeyDown(activate))
        {
            if (toolObject == woodCutter)
                woodCutterEquiped = false;
            if (toolObject == stoneCutter)
                stoneCutterEquiped = false;
            if (toolObject == huntingTool)
                huntingToolEquiped = false;
     
            anyToolEquiped = false;
            toolObject.SetActive(false);
            return;
        }
    }
}
