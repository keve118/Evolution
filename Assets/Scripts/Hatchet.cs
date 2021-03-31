using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatchet : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, toolContainer, fpsCam;
    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool globallayEquipped;
    public static bool LeftHandFull;

    private void Start()
    {
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
            globallayEquipped = false;
            LeftHandFull = false;
        }
        if (equipped)
        {
            globallayEquipped = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            LeftHandFull = true;
        }
    }


    private void Update()
    {
    
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !LeftHandFull)
            PickUp();

        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    private void PickUp()
    {
        equipped = true;
        LeftHandFull = true;

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
        LeftHandFull = false;
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
