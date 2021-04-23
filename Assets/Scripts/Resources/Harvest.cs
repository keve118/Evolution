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
    public int force = 0;
    public int timeFallen = 5;
    public GameObject rest;


    private void Start()
    {
         thisResource = transform.gameObject;
         health=startHealth;
    }

    //public void Cutting1() 
    //{
    //    //Reducera Liv       
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        if (Physics.Raycast(ray, out hit, 5) && ResourceCutter.woodCutterEquiped && gameObject.tag == "Wood")
    //        {
    //            health -= 2;
    //            //FindObjectOfType<SoundManager>().Play("CutWood");
    //        }

    //    }
    //    if (Physics.Raycast(ray, out hit, 1) && ResourceCutter.stoneCutterEquiped && gameObject.tag == "Stone")
    //    {
    //            health -= 2;
    //            //FindObjectOfType<SoundManager>().Play("CutStone");
    //    }
    //    if (Physics.Raycast(ray, out hit, 1) && ResourceCutter.fishingRodEquiped && gameObject.tag == "Food")
    //           health -= 2;

    //    if (Physics.Raycast(ray, out hit, 1) && ResourceCutter.huntingToolEquiped && gameObject.tag == "Food")
    //    {
    //            health -= 2;
    //            //FindObjectOfType<SoundManager>().Play("SpearAnimal");
    //    }
        


    //}

    private void Update()
    {       
        ////Faller
        if (health <= 0 && gameObject.tag == "Stone")
        {
            Falling();
            //FindObjectOfType<SoundManager>().Play("StoneDown");
            return;
        }
        if (health <= 0 && gameObject.tag == "Wood")
        {
            Falling();
            //FindObjectOfType<SoundManager>().Play("WoodDown");
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
        if (gameObject.tag == "Food" && !isFallen) 
        {
            Animator an = gameObject.GetComponent<Animator>();
            an.SetBool("isDead", true);
            isFallen = true;
        }
        if (gameObject.tag != "Food" && !isFallen)
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.mass = mass;
            rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
            isFallen = true;
        }

        StartCoroutine(DestroyThisResource());
    }

    IEnumerator DestroyThisResource()
    {
        //coll.enabled = false;
        //myRend.enabled = false;

        yield return new WaitForSeconds(timeFallen);
        Instantiate(rest, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
