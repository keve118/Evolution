using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRight : MonoBehaviour
{
    public Transform rightHand;


    void OnMouseDown()
    {       
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = rightHand.position;
        this.transform.parent = GameObject.Find("RightHand").transform;                      
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }




    //private void OnMouseUp()
    //{
    //    this.transform.parent = null;
    //    GetComponent<Rigidbody>().useGravity = true;
    //    holding = false;
    //}

}
