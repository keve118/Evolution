using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform middleHand;
    private bool middleCarry = false;

    private void Start()
    {
        middleHand = GameObject.Find("MiddleHand").transform;
    }


    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        this.transform.position = middleHand.position;
        this.transform.parent = GameObject.Find("MiddleHand").transform;

    }

    private void OnMouseUp()
    {
        transform.parent = null;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
    }





    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0) && !middleCarry)
    //    {
    //        middleCarry = true;
    //        GetComponent<BoxCollider>().enabled = false;
    //        GetComponent<Rigidbody>().useGravity = false;
    //        GetComponent<Rigidbody>().isKinematic = false;

    //        gameObject.transform.position = middleHand.position;

    //    }
    //    if (Input.GetMouseButtonDown(0) && middleCarry)
    //    {
    //        gameObject.transform.position = transform.position; 
    //        GetComponent<Rigidbody>().useGravity = true;
    //        GetComponent<BoxCollider>().enabled = true;
    //        GetComponent<Rigidbody>().isKinematic = true;
    //    }
    //}
}
