using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    GameObject thisResource;
    public int startHealth = 10;
    public int health;
    private bool isFallen = false;

    public int mass = 10;
    public int treeMass = 50;
    public int force = 0;
    public int timeFallen = 5;
    public GameObject rest;

    private void Start()
    {
        thisResource = transform.gameObject;
        health =startHealth;
    }

    private void Update()
    {       
        //Falling, health == 0 is a bad idea since the tools sometimes makes the health < 0 --> falling never happens
        if (health <= 0 && gameObject.tag == "Stone")
        {
            Falling();
        }
        if (health <= 0 && gameObject.tag == "Wood")
        {
            Falling();      
        }
        if (health <= 0 && gameObject.tag == "Food")
        {
            Falling();       
        }
    }

    public void Falling()    
    {
        if (gameObject.tag == "Food" && !isFallen) 
        {
            //animation is handled by the DeerAI script
            isFallen = true;
        }
        if (gameObject.tag != "Food" && !isFallen)
        {
            Rigidbody rigidBody = gameObject.AddComponent<Rigidbody>();
            rigidBody.isKinematic = false;
            rigidBody.useGravity = true;
            rigidBody.mass = mass;
            rigidBody.AddForce(Vector3.forward * force, ForceMode.Impulse);
            isFallen = true;
        }
        if(gameObject.tag=="Wood" && !isFallen) 
        {

            Rigidbody rigidBody = gameObject.AddComponent<Rigidbody>();
            rigidBody.isKinematic = false;
            rigidBody.useGravity = true;
            rigidBody.mass = treeMass;
            isFallen = true;
        }





        StartCoroutine(DestroyThisResource());
    }
    IEnumerator DestroyThisResource()
    {
        yield return new WaitForSeconds(timeFallen);
        Instantiate(rest, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
