using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{  
    void OnTriggerStay(Collider other) //Click??
    {
        if (other.tag == "Player") 
        {
            Destroy(gameObject);
            ResourceCutter.woodCutterAvailable = true;           
        }         
    }
}
