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
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other) //Click??
    {
        resourceHP -= 1; 

    }
}
