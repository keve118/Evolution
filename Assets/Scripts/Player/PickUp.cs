using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Transform middleHand;
    private GameObject pickedUpObject;
    private bool pickedUp = false;
    public GameObject rayObject;

    private void Start()
    {
        middleHand = GameObject.Find("MiddleHand").transform;
        pickedUpObject = gameObject;
        SnapToGround();
    }

    private void Update()
    {
        Ray ray = new Ray(rayObject.transform.position, rayObject.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10)) //RayCast To find object that should be carried
        {
            if ((hit.collider.tag == "GameObject" /*|| hit.collider.tag == "Workshop"*/) && Input.GetMouseButton(0) && !pickedUp)
            {
                pickedUp = true;
                pickedUpObject = hit.collider.gameObject;      
                pickedUpObject.GetComponent<Rigidbody>().useGravity = false;
                pickedUpObject.GetComponent<Rigidbody>().isKinematic = true;
                hit.collider.gameObject.transform.position = middleHand.transform.position;
            }
            else if (Input.GetMouseButton(1) && pickedUp)          
                SnapToGround();           
            if (pickedUp)            
                RotateObject();                
        }
        if (pickedUp)
            pickedUpObject.transform.position = middleHand.position;           
    }


    public void RotateObject()
    {
        if (Input.GetKey(KeyCode.E))        pickedUpObject.transform.Rotate(0.0f, 40 * Time.deltaTime, 0.0f);       
        else if (Input.GetKey(KeyCode.Q))   pickedUpObject.transform.Rotate(0.0f, -40.0f * Time.deltaTime, 0.0f);
    }

    public void SnapToGround() 
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(pickedUpObject.transform.position, -transform.up, out hit, Mathf.Infinity))        
            pickedUpObject.transform.position = hit.point;
        
        pickedUpObject.transform.position += new Vector3(0, 0.1f, 0); //0.1f margin for aesthetics 
        pickedUp = false;
        pickedUpObject = null;
    }
}
