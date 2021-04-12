using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public GameObject equipedAxe;

    void OnTriggerStay(Collider other) //Click??
    {
        if (other.tag == "Player") 
        {
            Destroy(gameObject);
            BoxCollider bc = equipedAxe.GetComponent<BoxCollider>();
            bc.enabled = false;
            ResourceCutter.woodCutterAvailable = true;
            
        }         
    }
}
