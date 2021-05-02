using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMenu : MonoBehaviour
{
    [Header("UI Settings")]
    public static bool activeBuildUI = false;
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

    [Header("Tools Settings")]
    public GameObject toolUI; 
    public static bool activeToolUI = false;

    private ResourceCutter resourceCutterScript;

    private void Start()
    {
        primitiveHutCost.text= "Cost of Building:\n Wood:" + primitiveHut.GetComponent<Cost>().woodCost + "\n Stone:" + primitiveHut.GetComponent<Cost>().stoneCost;
        firePlaceCost.text = "Cost of Building:\n Wood:" + firePlace.GetComponent<Cost>().woodCost + "\n Stone:" + firePlace.GetComponent<Cost>().stoneCost;
        workshopCost.text = "Cost of Building:\n Wood:" + workshop.GetComponent<Cost>().woodCost + "\n Stone:" + workshop.GetComponent<Cost>().stoneCost;
    }

    private void Update()
    {
        Vector3 forward = transform.TransformDirection(PlayerProperties.rayCastTransform.position);
        Ray ray = new Ray(PlayerProperties.rayCastOrigin, PlayerProperties.rayCastTransform.forward);
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (activeBuildUI)
            {
                CloseBuildUI();
                Cursor.visible = false;
            }
            else
            {
                OpenBuildUI();
                Cursor.visible = true;                           
            }        
        }

        if (Physics.Raycast(ray, out hit, 10))
        {
            //if (hit.collider.tag == "Wood")
            //    Debug.Log("Wood!");

            if (hit.collider.gameObject.name =="Workshop" && Input.GetMouseButton(1) && activeToolUI)
            {
                CloseToolUI();
                Cursor.visible = false;

            }
            else if (hit.collider.gameObject.name == "Workshop" && Input.GetMouseButton(1) && !activeToolUI)
            {
                OpenToolUI();
                Cursor.visible = true;

            }
        }
    }


    public void CloseBuildUI() 
    {
        buildUI.SetActive(false);
        Time.timeScale = 1f;
        activeBuildUI = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void OpenBuildUI()
    {
        buildUI.SetActive(true);
        Time.timeScale = 0f;
        activeBuildUI = true;
        Cursor.lockState = CursorLockMode.Confined;
    }


    public void CloseToolUI()
    {
        toolUI.SetActive(false);
        Time.timeScale = 1f;
        activeToolUI = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void OpenToolUI()
    {
        toolUI.SetActive(true);
        Time.timeScale = 0f;
        activeToolUI = true;
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
        CloseBuildUI();
    }
}
