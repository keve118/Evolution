<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
=======
>>>>>>> Stashed changes
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 300f;

<<<<<<< Updated upstream
	[SerializeField] private Transform playerBody;

=======
    [HideInInspector] public bool buildingModeOn = false;

    [SerializeField] private Transform playerBody;

    private PlayerControls playerControls;
    private InputAction mouseCoordinates;
    private Vector2 mousePosition;
    private float xRotation;

    private void Awake()
    {
        playerControls = new PlayerControls();
        mouseCoordinates = playerControls.Gameplay.Look;
        mouseCoordinates.performed += OnLookingChanged; //What happens when the control is used (callback to auto generated class)
        mouseCoordinates.canceled += OnLookingChanged; //What happens when control is not used any more (callback to auto generated class)
    }

    private void OnEnable() => mouseCoordinates.Enable(); // Input System helper

    private void OnDisable() => mouseCoordinates.Disable(); // Input System helper

    private void OnLookingChanged(InputAction.CallbackContext context) // Listens to the movment of the controls
    {
        mousePosition = context.ReadValue<Vector2>();
    }

>>>>>>> Stashed changes
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
<<<<<<< Updated upstream
	{
		float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
		float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;
=======
    {
        if (!buildingModeOn)
        {
            float mouseX = mousePosition.x * sensitivity * Time.deltaTime;
            float mouseY = mousePosition.y * sensitivity * Time.deltaTime;
>>>>>>> Stashed changes

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

<<<<<<< Updated upstream
		playerBody.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		transform.Rotate(Vector3.up * mouseX);
	}
=======
    }

>>>>>>> Stashed changes
}
