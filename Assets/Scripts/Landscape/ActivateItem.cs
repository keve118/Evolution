using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateItem : MonoBehaviour
{
    private Transform cameraPosition; 
    private bool visible = true;
    public float distanceToAppear = 1;
    Renderer objRenderer;
    private bool skipFunction=false;

    private void Start()
    {

        cameraPosition = Camera.main.transform;
        objRenderer = gameObject.GetComponentInChildren<Renderer>();
    }

    private void Update()
    {
        Checker();
    }

    private void Checker()
    {
        float distance = Vector3.Distance(cameraPosition.position, transform.position);

        if (distance < distanceToAppear)
        {
            if (!visible)
            {
                objRenderer.enabled = true; // Show Object
                visible = true;
            }
        }
        else if (distance > distanceToAppear)
        {
            objRenderer.enabled = false; // Hide Object
            visible = false;
        }
    }

}


