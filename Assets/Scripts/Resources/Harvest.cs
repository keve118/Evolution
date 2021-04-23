using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    public int startHealth=10;
    public int health;
    public int mass = 10;
    public int force = 0;
    public int timeFallen = 5;
    public GameObject rest;  

    private void Start()
    {       
        health = startHealth;
    }
    private void Update()
    {
        //Reducera Liv
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,1) && ResourceCutter.woodCutterEquiped && gameObject.tag == "Wood")
            {
                
                health -= 2;
                FindObjectOfType<SoundManager>().Play("CutWood");
            }
                           
            if (Physics.Raycast(ray, out hit, 1) && ResourceCutter.stoneCutterEquiped && gameObject.tag == "Stone")
            {
                health -= 2;
                FindObjectOfType<SoundManager>().Play("CutStone");
            }
            if (Physics.Raycast(ray, out hit, 1) && ResourceCutter.fishingRodEquiped && gameObject.tag == "Food")
                health -= 2;

            if (Physics.Raycast(ray, out hit, 1) && ResourceCutter.huntingToolEquiped && gameObject.tag == "Food")
            {
                health -= 2;
                FindObjectOfType<SoundManager>().Play("SpearAnimal");
            }
        }
        ////Faller
        if (health <= 0 && gameObject.tag == "Stone")
        {
            Falling();
            FindObjectOfType<SoundManager>().Play("StoneDown");
            return;
        }
        if (health <= 0 && gameObject.tag == "Wood")
        {
            Falling();
            FindObjectOfType<SoundManager>().Play("WoodDown");
            return;
        }
        if (health <= 0 && gameObject.tag == "Food")
        {
            Falling();
            //FindObjectOfType<SoundManager>().Play("CaughtFish");         
        }
        if (health <= 0 && gameObject.tag == "Food")
        {
            //Falling();
            //FindObjectOfType<SoundManager>().Play("");       
        }

        // We have two types of food, FISH & Deer, we have to differ these
        //Think sound for animals will be implemented in the Animator
        //Or we just tag them with FoodFish and FoodAnimal?? /Jessica

    }
    public void Falling()    
    {
        if (gameObject.tag == "Food") 
        {
            Animator an = gameObject.GetComponent<Animator>();
            an.SetBool("isDead", true);

        }
        if (gameObject.tag != "Food")
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
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
        Destroy(gameObject);
    }
}
