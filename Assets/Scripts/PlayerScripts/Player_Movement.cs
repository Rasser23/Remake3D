using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player_Movement : MonoBehaviour
{

    [Header("Movement")]

    [Header("Ground Check")]

    [Header("Jump")]

    [Header("Air Control")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public float jumpForce = 7f;
    public float groundDrag;
    public float moveSpeed;
    public float airMultiplier = 0.3f;
    public Transform orientation;
    bool grounded;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        if(grounded)
            rb.linearDamping = groundDrag;
        else 
            rb.linearDamping = 0f;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        float multiplier = grounded ? 1f : airMultiplier;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    
}
