using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMenu : MonoBehaviour
{
    public static bool activeUI = false;
    public GameObject buildUI;

    public Transform positionObject;

    public GameObject primitiveHut;

    private bool placed = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (activeUI)
            {
                CloseUI();
                Cursor.visible = false;
            }
            else
            {
                OpenUI();
                Cursor.visible = true;              
               
            }        
        }
    }

    public void CloseUI() 
    {
        buildUI.SetActive(false);
        Time.timeScale = 1f;
        activeUI = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenUI()
    {
        buildUI.SetActive(true);
        Time.timeScale = 0f;
        activeUI = true;
        Cursor.lockState = CursorLockMode.Confined;

    }
    public void PlacePrimitiveHut() 
    {
        Debug.Log("Hut selected");   
        Instantiate(primitiveHut,positionObject.transform.position , transform.rotation);
        CloseUI();


    }











}
