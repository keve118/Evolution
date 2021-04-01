using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerScript : MonoBehaviour
{
    public float moveSpeed;
    public float runSpeed;
    public float jumpHeight;
    public float gravity = -9.81f;

    [SerializeField] bool isGrounded;

    private float currentSpeed;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        currentSpeed = moveSpeed;
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

<<<<<<< Updated upstream:Assets/Scripts/MovementPlayerScript.cs
        if(isGrounded)
=======
        if (isGrounded)
>>>>>>> Stashed changes:Assets/Scripts/Player/MovementPlayerScript.cs
            Jump();

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            currentSpeed = runSpeed;
        }
<<<<<<< Updated upstream:Assets/Scripts/MovementPlayerScript.cs
        else
=======
        else if (isGrounded)
>>>>>>> Stashed changes:Assets/Scripts/Player/MovementPlayerScript.cs
        {
            currentSpeed = moveSpeed;
        }

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
