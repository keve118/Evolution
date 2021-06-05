using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp : MonoBehaviour
{
    //THESE COMMENTS ARE IN A TESTING PHASE

    public GameObject rayObject;
    
    private PlayerControls playerControls;
    private InputAction pickUpItem;
    private InputAction rotatePickedUpObject;
    private Transform middleHand;
    private GameObject pickedUpObject;
    private bool pickedUp = false;
    //private bool whenPickUpItem;
    private float rotationModifier;
    private void Start()
    {
        middleHand = GameObject.Find("MiddleHand").transform;
        pickedUpObject = gameObject;
        SnapToGround();
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
        pickUpItem = playerControls.Gameplay.PickUpObject;
        rotatePickedUpObject = playerControls.Gameplay.RotateBuilding;
        //pickUpItem.performed += context => whenPickUpItem = true;
        //pickUpItem.canceled += context => whenPickUpItem = false;

        rotatePickedUpObject.performed += OnRotate;
        rotatePickedUpObject.canceled += OnRotate;
        pickUpItem.performed += OnPickUp;
    }

    private void OnPickUp(InputAction.CallbackContext context)
    {
       if (!pickedUp)
       {
            PickUpObject();
       }
       else if (pickedUp)
       {
            SnapToGround();
       }
    }
  
    private void PickUpObject() 
    {
        Ray ray = new Ray(rayObject.transform.position, rayObject.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10)) //RayCast To find object that should be carried
        {
            if ((hit.collider.tag == "GameObject") &&/* whenPickUpItem && */!pickedUp)
            {
                pickedUp = true;
                pickedUpObject = hit.collider.gameObject;
                pickedUpObject.GetComponent<Rigidbody>().useGravity = false;
                pickedUpObject.GetComponent<Rigidbody>().isKinematic = true;
                hit.collider.gameObject.transform.position = middleHand.transform.position;
            }      
        }
    }

    private void OnRotate(InputAction.CallbackContext context)
    {
        rotationModifier = context.ReadValue<float>();
    }

    private void OnEnable() => playerControls.Enable();

    private void OnDisable() => playerControls.Disable();

    private void Update()
    {
        if (pickedUp) 
        {
            RotateObject();
            pickedUpObject.transform.position = middleHand.position;       
        }
    }
  
    public void RotateObject()
    {
        if (rotationModifier != 0 && rotationModifier > 0)        pickedUpObject.transform.Rotate(0.0f, 40 * Time.deltaTime, 0.0f);       
        else if (rotationModifier != 0 && rotationModifier < 0)   pickedUpObject.transform.Rotate(0.0f, -40.0f * Time.deltaTime, 0.0f);
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
