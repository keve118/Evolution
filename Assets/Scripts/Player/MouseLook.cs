using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
	private float xRotation;
	public float sensitivity = 300f;

	[HideInInspector] public bool buildingModeOn = false;

	[SerializeField] private Transform playerBody;

    private PlayerControls playerControls;
    private InputAction mouseCoordinates;
    private Vector2 mousePosition;

    private void Awake()
    {
        playerControls = new PlayerControls();
        mouseCoordinates = playerControls.Gameplay.Look;
        mouseCoordinates.performed += OnLookingChanged;
        mouseCoordinates.canceled += OnLookingChanged;
    }

    private void OnLookingChanged(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }

    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
	}

    void Update()
	{
        if (!buildingModeOn) 
		{
            float mouseX = mousePosition.x * sensitivity * Time.deltaTime;
            float mouseY = mousePosition.y * sensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            playerBody.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

	}

    private void OnEnable() // Input System helper
    {
        mouseCoordinates.Enable();
    }

    private void OnDisable() // Input System helper
    {
        mouseCoordinates.Disable();
    }
}
