using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<SoundManager>().Play("PickUpTool");
            Destroy(gameObject);
            ResourceCutter.huntingToolAvailable = true;

        }
    }
}
