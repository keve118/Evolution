using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    private GameObject thisGameObject;
    public float startHealth=10;
    public float health;
    public int mass = 10;
    public int force = 0;
    public float timeFallen = 5f;
    public GameObject rest;
    

    private void Start()
    {
        thisGameObject = gameObject;
        health = startHealth;
    }

    private void OnMouseDown()
    {
        health -= 2;

        if (ResourceCutter.stoneCutterEquiped && health <=0 && thisGameObject.tag=="Stone")       
            Falling();
        
        if (ResourceCutter.woodCutterEquiped && health <= 0 && thisGameObject.tag == "Wood")
            Falling();

        if (ResourceCutter.fishingRodEquiped && health <= 0 && thisGameObject.tag == "Food")
            Falling();

        if (ResourceCutter.huntingToolEquiped && health <= 0 && thisGameObject.tag == "Food")
            Falling();
    }

    public void Falling()    
    {
        Rigidbody rb = thisGameObject.AddComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.mass = mass;
        rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
        StartCoroutine(DestroyThisResource());
    }
    IEnumerator DestroyThisResource()
    {

        yield return new WaitForSeconds(timeFallen);
        Instantiate(rest, transform.position, transform.rotation);
        Destroy(thisGameObject);
    }
}
