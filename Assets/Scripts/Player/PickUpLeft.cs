using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpLeft : MonoBehaviour
{
 
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, toolContainer, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;
   
    public bool equipped;
    public static bool slotFull;
    
    private PlayerControls playerControls;
    private InputAction dropItem;
    private bool isPressedKeyE;

    private void Awake()
    {
        playerControls = new PlayerControls();
        dropItem = playerControls.Gameplay.DropItem;

        dropItem.performed += context => isPressedKeyE = true;
        dropItem.canceled += context => isPressedKeyE = false;
    }

    private void OnEnable() => playerControls.Enable();

    private void OnDisable() => playerControls.Disable();


    private void Start()
    {
        if (!equipped) 
        {   
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped) 
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }
    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) 
            PickUp();

        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();      
    } 
    private void PickUp() 
    {
        equipped = true;
        slotFull = true;

        //Position, Scale, Rotation of object
        transform.SetParent(toolContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        rb.isKinematic = true;
        coll.isTrigger = true;    
        //cutTreeScript.enabled = true;

    }
    private void Drop() 
    {
        equipped = false;
        slotFull = false;
        transform.SetParent(null);
        rb.useGravity = true;
        rb.isKinematic = false;
        coll.isTrigger = false;

        //Forces
        //rb.velocity = player.GetComponent<Rigidbody>().velocity;
        //rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        //rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);
        //float random = Random.Range(1f, 1f);
        //rb.AddTorque(new Vector3(random, random, random)*10);
        //cutTreeScript.enabled = false;
    }
}
