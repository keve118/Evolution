using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    Renderer objRenderer;

    private void Start()
    {
   
        objRenderer = gameObject.GetComponentInChildren<Renderer>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            gameObject.SetActive(false);
    }
}


