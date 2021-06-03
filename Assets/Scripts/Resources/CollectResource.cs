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

            if (gameObject.tag=="Wood" && PlayerProperties.amountWood <= PlayerProperties.maxAmountWood - 1)
                PlayerProperties.amountWood += 1;

            if (gameObject.tag == "SmallWood" && PlayerProperties.amountWood <= PlayerProperties.maxAmountWood-0.25)
                PlayerProperties.amountWood += 0.25f;

            if (gameObject.tag == "Stone" && PlayerProperties.amountStone <= PlayerProperties.maxAmountStone - 1)
                PlayerProperties.amountStone += 1;

            if (gameObject.tag == "Food" && PlayerProperties.amountFood <= PlayerProperties.maxAmountFood - 1)
                PlayerProperties.amountFood += 1;
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player" && gameObject.tag=="Wood" && PlayerProperties.amountWood < PlayerProperties.maxAmountWood) 
            resourceHP -= 1;
        if (other.tag == "Player" && gameObject.tag == "SmallWood" && PlayerProperties.amountWood < PlayerProperties.maxAmountWood)
            resourceHP -= 1;


        if (other.tag == "Player" && gameObject.tag == "Food" && PlayerProperties.amountFood < PlayerProperties.maxAmountFood)
            resourceHP -= 1;
        if (other.tag == "Player" && gameObject.tag == "Stone" && PlayerProperties.amountStone < PlayerProperties.maxAmountStone)
            resourceHP -= 1;
    }
}
