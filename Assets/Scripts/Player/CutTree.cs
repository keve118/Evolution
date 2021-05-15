using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTree : MonoBehaviour
{
    public PickUpLeft pickUpScrift;
    public GameObject bush1Broken;
    bool cut = false;

    void OnMouseDown()
    {
        if(cut == false) 
        {
            Instantiate(bush1Broken, transform.position, transform.rotation);
            Destroy(gameObject);
            cut = true;
        }
   
    }
}
