using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectResource : MonoBehaviour
{
    public int resourceHP = 10; 

    void Update()
    {
        if (resourceHP < 1)
        {
            //sound clip when picking up a resource
            FindObjectOfType<SoundManager>().Play("PickUpResource");

            if (gameObject.tag=="Wood")
                PlayerProperties.amountWood += 1;

            if (gameObject.tag == "SmallWood")
                PlayerProperties.amountWood += 0.25f;

            if (gameObject.tag == "Stone")
                PlayerProperties.amountStone += 1;


            if (gameObject.tag == "Food")
                PlayerProperties.amountFood += 1;
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player") 
            resourceHP -= 1; 
    }
}
