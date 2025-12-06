using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player_Movement : MonoBehaviour // this script controls the movement of the player 
{

    [Header("Movement")] // label in inspector 

    [Header("Ground Check")] // label in inspector 

    [Header("Jump")] // label in inspector
    public float playerHeight; // height of the player used for ground check raycast 
    public LayerMask whatIsGround; // defines which layers count as ground
    public float jumpForce = 7f; // upward force appplied when jumping 
    public float groundDrag; // amount of drag applied while on ground
    public float moveSpeed; // playermovement speed
    public Transform orientation; // reference for determing forward/right position 

    bool grounded; // checking: is the player touching the ground?
    float horizontalInput; // input along the x-axis 
    float verticalInput; // input along the y-axis

    Vector3 moveDirection; // final movement direction based on the inputs 
    [SerializeField] private Rigidbody rb; // reference to the rigidbody 

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // get the rigidbody from the player 
        rb.freezeRotation = true; // prevents the player from tiping over
    }
    private void Update()
    {
        // raycast downward to check if the player is grounded 
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();

        if (Input.GetKeyDown(KeyCode.Space) && grounded) // jump only if grounded and player press the space button 
        {
            Jump();
        }

        if(grounded) // apply drag only when grounded
            rb.linearDamping = groundDrag;
        else 
            rb.linearDamping = 0f;
    }

    private void FixedUpdate()
    {
        MovePlayer(); // movement of the player 
    }

    private void MyInput()
    {
       // values from Unitys input system 
       horizontalInput = Input.GetAxisRaw("Horizontal"); // A/D keys
        verticalInput = Input.GetAxisRaw("Vertical"); // WS keys
    }

    private void MovePlayer()
    {
        // combine input with the orientations forward/right directions 
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // add movement force to the player 
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void Jump()
    {
        // reset vertical velocity so jump is consistent 
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // apply sudden upward force 
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    
}
