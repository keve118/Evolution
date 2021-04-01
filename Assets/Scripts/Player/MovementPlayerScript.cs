using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerScript : MonoBehaviour
{
    public float walkSpeed, runSpeed;
    public float jumpHeight;
    public float gravity = -9.18f;

    [SerializeField] bool isGrounded;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }


        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = transform.right * (x * 0.75f) + transform.forward * z;

        controller.Move(moveDirection * Time.deltaTime * currentSpeed);

        if(Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            currentSpeed = runSpeed;
        }
        else if (isGrounded)
        {
            currentSpeed = walkSpeed;
        }

        if(isGrounded)
            Jump();

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
    }
}
