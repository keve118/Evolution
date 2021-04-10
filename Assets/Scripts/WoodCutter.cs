using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCutter : MonoBehaviour
{
   public GameObject woodCutter;
    private bool isEquiped;

    private void Update()
    {
        if (!woodCutter.activeSelf && Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            isEquiped = true;
            woodCutter.SetActive(true);

        }

        else if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            isEquiped = false;
            woodCutter.SetActive(false);

        }

        //Raycast
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit; 

        if(Physics.Raycast(transform.position, fwd, out hit, 10)) 
        { 
            if(hit.collider.tag=="Wood" && Input.GetMouseButton(0) && isEquiped == true) 
            {
                CutAble cutScript = hit.collider.gameObject.GetComponent<CutAble>();
                cutScript.resourceHealth--;           
            }       
        }
    }
}
