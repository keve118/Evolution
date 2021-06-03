using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BuildingMenu : MonoBehaviour
{
    [Header("UI Settings")]
    public static bool activeBuildUI = false;
    public GameObject buildUI;

    [Header("Spawn Settings")]
    public Transform positionBuildings;
    private Transform positionTools;

    [Header("Buildings")]
    public GameObject primitiveHut;
    public GameObject firePlace;
    public GameObject workshop;
    public GameObject storage;

    [Header("Tools")]
    public GameObject stoneAgeAxe;
    public GameObject stoneAgePickAxe;
    public GameObject stoneAgeSpear;

    [Header("Building Text Settings")]
    public Text primitiveHutCost;
    public Text firePlaceCost;
    public Text workshopCost;
    public Text storageCost;
    public Text stoneAgeAxeCost;
    public Text stoneAgePickAxeCost;
    public Text stoneAgeSpearCost;

    [Header("Tools Settings")]
    public GameObject toolUI;
    public static bool activeToolUI = false;

    [Header("General Settings")]
    public Camera MainCamera;
    public Camera UsingCamera;
    public float timePassed = 2f;
    public GameObject pointer;
    public GameObject player;

    //Input
    private PlayerControls playerContols;
    private InputAction openCraftMenu;
    private InputAction openBuildingMenu;
    private bool isOpenCraftMenu;
    private bool isOpenBuildingMenu;
    private bool isCraftKeyDown;
    private bool isBuildKeyDown;

    private void Awake()
    {
        playerContols = new PlayerControls();
        openCraftMenu = playerContols.Gameplay.CraftItemMenu;
        openBuildingMenu = playerContols.Gameplay.BuildingMenu;

        openCraftMenu.performed += context => isOpenCraftMenu = true;
        openCraftMenu.canceled += context => isOpenCraftMenu = false;
        openBuildingMenu.performed += context => isOpenBuildingMenu = true;
        openBuildingMenu.canceled += context => isOpenBuildingMenu = false;
    }

    private void OnEnable() => playerContols.Enable();
    private void OnDisable() => playerContols.Disable();

    private void Start()
    {
        MainCamera.enabled = true;
        UsingCamera.enabled = false;
    }

    private void Update()
    {

        if (!isOpenBuildingMenu && isBuildKeyDown) //Disables spamming menu
        {
            isBuildKeyDown = false;
        }

        Ray ray = new Ray(PlayerProperties.rayCastOrigin, PlayerProperties.rayCastTransform.forward);
        RaycastHit hit;

        if (isOpenBuildingMenu && !isBuildKeyDown)
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
            isBuildKeyDown = true;
        }

        if (!isOpenCraftMenu && isCraftKeyDown) //Disables spamming menu
        {
            isCraftKeyDown = false;
        }

        if (Physics.Raycast(ray, out hit, 10))
        {

            if (isOpenCraftMenu && !isCraftKeyDown)
            {
                Debug.Log("Program entered");

                if (hit.collider.tag == "Workshop" && isOpenCraftMenu && activeToolUI)
                {
                    CloseToolUI();
                    Cursor.visible = false;
                    positionTools = hit.collider.gameObject.transform.Find("spawnPoint");
                }
                else if (hit.collider.tag == "Workshop" && isOpenCraftMenu && !activeToolUI)
                {
                    OpenToolUI();
                    Cursor.visible = true;
                }
                isCraftKeyDown = true;
            }
        }

        primitiveHutCost.text = "Cost of Building:\n Wood:" + primitiveHut.GetComponent<Cost>().woodCost + "\n Stone:" + primitiveHut.GetComponent<Cost>().stoneCost;
        firePlaceCost.text = "Cost of Building:\n Wood:" + firePlace.GetComponent<Cost>().woodCost + "\n Stone:" + firePlace.GetComponent<Cost>().stoneCost;
        workshopCost.text = "Cost of Building:\n Wood:" + workshop.GetComponent<Cost>().woodCost + "\n Stone:" + workshop.GetComponent<Cost>().stoneCost;
        storageCost.text = "Cost of Building:\n Wood:" + storage.GetComponent<Cost>().woodCost + "\n Stone:" + storage.GetComponent<Cost>().stoneCost;

        stoneAgeAxeCost.text = "Cost of Building:\n Wood:" + stoneAgeAxe.GetComponent<Cost>().woodCost + "\n Stone:" + stoneAgeAxe.GetComponent<Cost>().stoneCost;
        stoneAgePickAxeCost.text = "Cost of Building:\n Wood:" + stoneAgePickAxe.GetComponent<Cost>().woodCost + "\n Stone:" + stoneAgePickAxe.GetComponent<Cost>().stoneCost;
        stoneAgeSpearCost.text = "Cost of Building:\n Wood:" + stoneAgeSpear.GetComponent<Cost>().woodCost + "\n Stone:" + stoneAgeSpear.GetComponent<Cost>().stoneCost;
    }

    public void CloseBuildUI()
    {
        buildUI.SetActive(false);
        Time.timeScale = 1f;
        activeBuildUI = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void OpenBuildUI()
    {
        buildUI.SetActive(true);
        Time.timeScale = 0f;
        activeBuildUI = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
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
        {
            if (activeBuildUI)
                CloseBuildUI();
            if (activeToolUI)
                CloseToolUI();
        }
    }
    public void SpawnObject(GameObject buildingObject)
    {
        if (buildingObject.tag == "Tool")
            Instantiate(buildingObject, positionTools.transform.position, transform.rotation);
        else
            Instantiate(buildingObject, positionBuildings.transform.position, transform.rotation);

        if (activeBuildUI)
            CloseBuildUI();

        if (activeToolUI)
            CloseToolUI();
    }
}
