using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestResource : MonoBehaviour
{
    public static int stoneUnits = 0;
    public static int woodUnits = 0;
    public static int foodUnits = 0;

    void Start()
    {
    }

    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Stone")
        {
            stoneUnits += 1;
        }

        if (other.tag == "Wood")
        {
            woodUnits += 1;
        }

        if (other.tag == "Food")
        {
            foodUnits += 1;
        }

        Debug.Log("Stones: " + stoneUnits + "   Wood: " + woodUnits + "   Food: " + foodUnits);
    }
}
