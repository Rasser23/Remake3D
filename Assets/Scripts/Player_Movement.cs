using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player_Movement : MonoBehaviour
{

    [Header("Movement")]

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public float groundDrag;
    public float moveSpeed;
    public Transform orientation;

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

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
    
}
