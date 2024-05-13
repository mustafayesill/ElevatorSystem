using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trial : MonoBehaviour
{
    public float moveSpeed;
    public float WalkSpeed, SprintSpeed;
    public float JumpForce;

    Vector3 moveDirection;
    Rigidbody rb;


    float horizontalX, verticalZ;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation=true;
    }

    
    private void FixedUpdate()
    {
        myInputs();
        Jump();
    }

    private void myInputs()
    {
        horizontalX = Input.GetAxisRaw("Horizontal");
        verticalZ = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontalX, 0, verticalZ);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = SprintSpeed;
        }
        else //if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = WalkSpeed;
        }
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(transform.up *JumpForce, ForceMode.Impulse);
        }
        
    }



}
