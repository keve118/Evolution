using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Transform middleHand;
    private bool middleCarry = false;
    private Rigidbody gRigidbody;

    private void Start()
    {
        gRigidbody = GetComponent<Rigidbody>();
        middleHand = GameObject.Find("MiddleHand").transform;

        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity))
        {
            transform.Rotate(0, 0, 0);
            transform.position = hit.point;
        }
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.position += new Vector3(0, 0.1f, 0);
    }


    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;    
        gRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        this.transform.position = middleHand.position;
        this.transform.parent = GameObject.Find("MiddleHand").transform;

    }


    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        RaycastHit hit = new RaycastHit();
        if(Physics.Raycast(transform.position,-transform.up,out hit, Mathf.Infinity))
        {
            transform.Rotate(0, 0, 0);
            transform.position = hit.point;
        }
        transform.rotation = new Quaternion(0, 0, 0,0);
        transform.position += new Vector3(0, 0.1f, 0);
    }

}
