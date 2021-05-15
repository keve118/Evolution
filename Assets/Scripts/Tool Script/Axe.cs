using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{  
    void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player") 
        {
            FindObjectOfType<SoundManager>().Play("PickUpTool");
            Destroy(gameObject);
            ToolSwitching.woodCutterAvailable = true;           
        }         
    }
}
