using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravity = -9.18f;

    [SerializeField] bool isGrounded;

    private CharacterController controller;
    private Vector3 playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = gravity;
        }


        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;

        controller.Move(moveDirection * Time.deltaTime * moveSpeed);

        Jump();

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpForce * -3.0f * gravity);
        }
    }
}
