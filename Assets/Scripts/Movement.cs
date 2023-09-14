using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 10f;
    public float turnSpeed = 5f;
    

    private Animator animator;
    private Rigidbody rb;
    private CharacterController characterController;
    private bool isJumping;
    private bool isSliding;
    private bool isRunning;
    private float movementSpeed;
    private bool isGrounded;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        isRunning = Input.GetKey(KeyCode.LeftShift);
        isJumping = Input.GetKeyDown(KeyCode.Space);
        isSliding = Input.GetKeyDown(KeyCode.DownArrow);
        

        // Jumping
        if (isJumping )
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump");
        }
        
        // Sliding
        if (isSliding)
        {
            animator.SetTrigger("Slide");
        }

        float moveSpeed = isRunning ? runSpeed : walkSpeed;
        
        movementSpeed = new Vector2(horizontalInput, verticalInput).magnitude * moveSpeed;
        
        animator.SetFloat("Speed", movementSpeed);
        
        animator.SetBool("IsRunning", isRunning);
        
    }
    private void FixedUpdate()
    {

        // Apply movement
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0f);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float moveSpeed = isRunning ? runSpeed : walkSpeed;
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * (moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(transform.position + movement);
       
        // Turn player towards movement direction
        if (horizontalInput != 0f )
        {
            
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0f, 0f));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);
       
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, Vector3.down);
    }
}
