using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMenu : MonoBehaviour
{
    [Header("UI Settings")]
    public static bool activeUI = false;
    public GameObject buildUI;

    [Header("Spawn Settings")]
    public Transform positionObject;

    [Header("Buildings")]
    public GameObject primitiveHut;
    public GameObject firePlace;
    public GameObject workshop;
    private bool placed = false;

    [Header("Button Settings")]
    public Button primitiveHutButton;
    public Button fireplaceButton;
    public Button workshopButton;

    [Header("Text Settings")]
    public Text primitiveHutCost;
    public Text firePlaceCost;
    public Text workshopCost;

    private void Start()
    {
        primitiveHutCost.text= "Cost of Building:\n Wood:" + primitiveHut.GetComponent<Cost>().woodCost + "\n Stone:" + primitiveHut.GetComponent<Cost>().stoneCost;
        firePlaceCost.text = "Cost of Building:\n Wood:" + firePlace.GetComponent<Cost>().woodCost + "\n Stone:" + firePlace.GetComponent<Cost>().stoneCost;
        workshopCost.text = "Cost of Building:\n Wood:" + workshop.GetComponent<Cost>().woodCost + "\n Stone:" + workshop.GetComponent<Cost>().stoneCost;
    }

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

    public void CostOfObject(GameObject buildingObject)
    {
        int costOfWood = buildingObject.GetComponent<Cost>().woodCost;
        int costOfStone = buildingObject.GetComponent<Cost>().stoneCost;
        int costOfFood = buildingObject.GetComponent<Cost>().foodCost;

        if (costOfWood <= PlayerProperties.amountWood)
        {
            if (costOfStone <= PlayerProperties.amountStone)
            {
                if (costOfFood <= PlayerProperties.amountFood)
                {
                    SpawnObject(buildingObject);

                    PlayerProperties.amountWood -= costOfWood;
                    PlayerProperties.amountFood -= costOfFood;
                    PlayerProperties.amountStone -= costOfStone;

                }
            }
        }
        else
            Debug.Log("Insufficient Funds!");
    }
    public void SpawnObject(GameObject buildingObject)
    {
        Instantiate(buildingObject, positionObject.transform.position, transform.rotation);
        CloseUI();
    }
}
