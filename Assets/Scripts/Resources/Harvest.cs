using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    private GameObject thisGameObject;
    public int startHealth=10;
    public int health;
    public int mass = 10;
    public int force = 0;
    public int timeFallen = 5;
    public GameObject rest;  
    private void Start()
    {
        thisGameObject = gameObject;
        health = startHealth;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Stone" && ResourceCutter.stoneCutterAvailable && thisGameObject.tag == "Stone" && Input.GetMouseButtonDown(0))
        {
            health -= 2;
            FindObjectOfType<SoundManager>().Play("CutStone");
        }
        if (other.tag == "Wood" && ResourceCutter.woodCutterAvailable && thisGameObject.tag == "Wood" && Input.GetMouseButtonDown(0))
        {
            health -= 2;
            FindObjectOfType<SoundManager>().Play("CutWood");
        }
        if (other.tag == "Spear" && ResourceCutter.huntingToolEquiped && thisGameObject.tag == "Food" && Input.GetMouseButtonDown(0))
        {
            health -= 2;
            FindObjectOfType<SoundManager>().Play("SpearAnimal");
        }
    }
    private void Update()
    {
        ////Faller
        if (health <= 0 && thisGameObject.tag == "Stone")
        {
            Falling();
            FindObjectOfType<SoundManager>().Play("ResourceDown");
            return;
        }
        if (health <= 0 && thisGameObject.tag == "Wood")
        {
            Falling();
            FindObjectOfType<SoundManager>().Play("ResourceDown");
            return;
        }
        if (health <= 0 && thisGameObject.tag == "Food")
        {
            Falling();
            //FindObjectOfType<SoundManager>().Play("ResourceDown");
            return;
            //FindObjectOfType<SoundManager>().Play("CaughtFish");         
        }
        //if (health <= 0 && thisGameObject.tag == "Food")
        //{
        //    //Falling();
        //    //FindObjectOfType<SoundManager>().Play("");       
        //}

        // We have two types of food, FISH & Deer, we have to differ these
        //Think sound for animals will be implemented in the Animator
        //Or we just tag them with FoodFish and FoodAnimal?? /Jessica

    }
    public void Falling()    
    {
        if (thisGameObject.tag == "Food") 
        {
            Animator an = thisGameObject.GetComponent<Animator>();
            an.SetBool("isDead", true);

        }
        if (thisGameObject.tag != "Food")
        {
            Rigidbody rb = thisGameObject.AddComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.mass = mass;
            rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
        }
        StartCoroutine(DestroyThisResource());
    }

    IEnumerator DestroyThisResource()
    {
        yield return new WaitForSeconds(timeFallen);
        Instantiate(rest, transform.position, transform.rotation);
        Destroy(thisGameObject);
    }
}
