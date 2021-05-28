using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResourceCutter : MonoBehaviour
{
    [Header("General Settings")]
    public static bool anyToolEquiped=false;
    private Ray ray;
    public GameObject rayObject;
    private PlayerControls playerControls;
    private InputAction interact;
    private bool isInteracting;

    private void Awake()
    {
        playerControls = new PlayerControls();
        interact = playerControls.Gameplay.Attack;
        interact.performed += OnInteracting;
        interact.canceled += OnInteracting;
    }

    private void OnInteracting(InputAction.CallbackContext context)
    {
        isInteracting = context.ReadValueAsButton();
    }

    private void OnEnable() => playerControls.Enable();
    private void OnDisable() => playerControls.Disable();

    private void FixedUpdate()
    {
        Ray ray = new Ray(rayObject.transform.position, rayObject.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10))
        {
            if (hit.collider.tag == "Wood" && isInteracting && ToolSwitching.woodCutterEquiped)
            {
                Harvest harvestScript = hit.collider.gameObject.GetComponent<Harvest>();
                FindObjectOfType<SoundManager>().Play("CutWood");
                harvestScript.health--;
            }
            if (hit.collider.tag == "Stone" && isInteracting && ToolSwitching.stoneCutterEquiped)
            {
                Harvest harvestScript = hit.collider.gameObject.GetComponent<Harvest>();
                FindObjectOfType<SoundManager>().Play("CutStone");
                harvestScript.health--;
            }
            if (hit.collider.tag == "Food" && isInteracting && ToolSwitching.huntingToolEquiped)
            {
                Harvest harvestScript = hit.collider.gameObject.GetComponent<Harvest>();
                FindObjectOfType<SoundManager>().Play("SpearAnimal");
                harvestScript.health--;
            }
        }
    }
}
