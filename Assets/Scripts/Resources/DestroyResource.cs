using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyResource : MonoBehaviour
{
    public int resourceHP = 10; 

    void Start()
    {

    }

    void Update()
    {
        if (resourceHP < 1)
        {
         

            if(gameObject.tag=="Wood")
            {
                FindObjectOfType<SoundManager>().Play("PickUpResource");
                PlayerProperties.amountWood += 1;
            }
                

            if (gameObject.tag == "Stone")
                PlayerProperties.amountStone += 1;


            if (gameObject.tag == "Food")
                PlayerProperties.amountFood += 1;

            Destroy(gameObject);
            Debug.Log("Wood:" + PlayerProperties.amountWood + "    Stone:" + PlayerProperties.amountStone + "   Food:" + PlayerProperties.amountFood);

        }
    }

    void OnTriggerStay(Collider other) //Click??
    {
        if (other.tag == "Player") 
            resourceHP -= 1; 
    }
}
