using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderUI : MonoBehaviour
{

    public GameObject builderUI;

    public void Update()
    {
        if (!builderUI.activeSelf && Input.GetKeyDown(KeyCode.E)) 
        {
            builderUI.SetActive(true);       
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            builderUI.SetActive(false);
            return;
        }
    }
}
