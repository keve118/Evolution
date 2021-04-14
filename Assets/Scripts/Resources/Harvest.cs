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
    private void Update()
    {
        //Reducera Liv
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10) && ResourceCutter.woodCutterEquiped && thisGameObject.tag == "Wood")            
                health -= 2;            
            if (Physics.Raycast(ray, out hit, 10) && ResourceCutter.stoneCutterEquiped && thisGameObject.tag == "Stone")          
                health -= 2;          
            if (Physics.Raycast(ray, out hit, 10) && ResourceCutter.fishingRodEquiped && thisGameObject.tag == "Food")           
                health -= 2;          
            if (Physics.Raycast(ray, out hit, 10) && ResourceCutter.huntingToolEquiped && thisGameObject.tag == "Food")           
                health -= 2;            
        }
        ////Faller
        if (health <= 0 && thisGameObject.tag == "Stone")
        {
            Falling();
            FindObjectOfType<SoundManager>().Play("CutStone");
            return;
        }
        if (health <= 0 && thisGameObject.tag == "Wood")
        {
            Falling();
            FindObjectOfType<SoundManager>().Play("CutWood");
            return;
        }
        if (health <= 0 && thisGameObject.tag == "Food")
        {
            Falling();
            //FindObjectOfType<SoundManager>().Play("CaughtFish");         
        }
        if (health <= 0 && thisGameObject.tag == "Food")
        {
            //Falling();
            //FindObjectOfType<SoundManager>().Play("WildAnimalKill");       
        }

        // We have two types of food, FISH & Deer, we have to differ these
        //Think sound for animals will be implemented in the Animator

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
