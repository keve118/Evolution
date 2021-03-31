using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchetRayCast : MonoBehaviour
{
    //variables
    public GameObject hatchet;
    private bool isEquiped = false;

    private void Update()
    {
        if(!hatchet.activeSelf && Input.GetKeyDown(KeyCode.E)) 
        {
            isEquiped = true;
            hatchet.SetActive(true);
            hatchet.GetComponent<Renderer>().enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            isEquiped = false;
            hatchet.SetActive(false);
            hatchet.GetComponent<Renderer>().enabled = false;
        }

        //Raycast
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, forward, out hit, 10)) 
        { 
            if(hit.collider.tag =="Bush" && Input.GetMouseButton(0) && isEquiped == true)           
            {
                Bush treeScript = hit.collider.gameObject.GetComponent<Bush>();
                treeScript.bushHealth--;

            
            }
        }


    }



}
