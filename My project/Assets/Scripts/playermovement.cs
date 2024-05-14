using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playermovement : MonoBehaviour
{
    public float moveSpeed;
    public float walkSpeed = 5f;
    public float jumpForce,jumpCooldown;
    public float sprintSpeed=8f;
    public float groundCheckDistance =8f;
    Vector3 moveDirection;
    bool isGrounded;
    bool readyToJump;

    float horizontalnp;
    float verticalInp;
    Rigidbody rb;

    public TextMeshProUGUI speedText, StatusText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }
    private void Update()
    {
        GroundCheck();
        speedText.text = moveSpeed.ToString();
    }
    private void FixedUpdate()
    {
        MovePlayer();
        Jump();
    }
    private void MovePlayer()
    {
        horizontalnp = Input.GetAxisRaw("Horizontal");
        verticalInp = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(horizontalnp, 0, verticalInp);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
            StatusText.text = "Sprinting";
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = walkSpeed;
            StatusText.text = "Walking";
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && readyToJump)
        {
            readyToJump = false;
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            StatusText.text = "Jumping";
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    private void GroundCheck()
    {
        Ray ray = new Ray(transform.position + Vector3.up, Vector3.down);
        RaycastHit hit;
        isGrounded = Physics.Raycast(ray, out hit, groundCheckDistance);
        //isGrounded = true;
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
