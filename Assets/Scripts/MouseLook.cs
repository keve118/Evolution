using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

	private float xRotation;
	public float sensitivity = 300f;

	[SerializeField] private Transform playerBody;

    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
	}

    void Update()
	{
		float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
		float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		playerBody.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		transform.Rotate(Vector3.up * mouseX);
	}
}
