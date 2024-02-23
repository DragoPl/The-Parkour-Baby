using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float movementSpeed = 5f;
    public float sprintSpeed = 10f; // Speed when sprinting
    public float mouseSensitivity = 100f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Rigidbody rb;
    private Camera playerCamera;
    private float verticalLookRotation;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Movement
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        // Sprinting
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            Vector3 velocity = (moveHorizontal + moveVertical).normalized * sprintSpeed;
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
        else
        {
            Vector3 velocity = (moveHorizontal + moveVertical).normalized * movementSpeed;
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        playerCamera.transform.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

    }
}
