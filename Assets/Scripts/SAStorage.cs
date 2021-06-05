using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAStorage : MonoBehaviour
{
    public GameObject storage;

    public void IncreseMaxWood(GameObject gb) 
    {
        if (PlayerProperties.amountWood >= gb.GetComponent<Cost>().woodCost && PlayerProperties.amountStone >= gb.GetComponent<Cost>().stoneCost)
        {
            PlayerProperties.maxAmountWood = 40;
            Debug.Log("Max Amount increased!" + PlayerProperties.maxAmountWood);
        }
    }


}
