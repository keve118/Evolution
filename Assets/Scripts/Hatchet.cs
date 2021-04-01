using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatchet : MonoBehaviour
{
    public GameObject hatchet;
    private bool isEquiped;

    private void Update()
    {
        if (!hatchet.activeSelf && Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            isEquiped = true;
            hatchet.SetActive(true);

        }

        else if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            isEquiped = false;
            hatchet.SetActive(false);

        }

        //Raycast
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit; 

        if(Physics.Raycast(transform.position, fwd, out hit, 10)) 
        { 
            if(hit.collider.tag=="Bush" && Input.GetMouseButton(0) && isEquiped == true) 
            {
                Bush bushScript = hit.collider.gameObject.GetComponent<Bush>();
                bushScript.bushHealth--;

            
            }
        
        }



    }




}
