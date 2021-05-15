using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCutter : MonoBehaviour
{
    [Header("General Settings")]
    public static bool anyToolEquiped = false;
    private Ray ray;
    public GameObject rayObject;

    private void Update()
    {
        Ray ray = new Ray(rayObject.transform.position, rayObject.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10))
        {
            if (hit.collider.tag == "Wood" && Input.GetMouseButton(0) && ToolSwitching.woodCutterEquiped)
            {
                Harvest harvestScript = hit.collider.gameObject.GetComponent<Harvest>();
                FindObjectOfType<SoundManager>().Play("CutWood");
                harvestScript.health--;
            }
            if (hit.collider.tag == "Stone" && Input.GetMouseButton(0) && ToolSwitching.stoneCutterEquiped)
            {
                Harvest harvestScript = hit.collider.gameObject.GetComponent<Harvest>();
                FindObjectOfType<SoundManager>().Play("CutStone");
                harvestScript.health--;
            }
            if (hit.collider.tag == "Food" && Input.GetMouseButton(0) && ToolSwitching.huntingToolEquiped)
            {
                Harvest harvestScript = hit.collider.gameObject.GetComponent<Harvest>();
                FindObjectOfType<SoundManager>().Play("SpearAnimal");
                harvestScript.health--;
            }
        }
    }
}
