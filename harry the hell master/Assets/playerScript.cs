using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private Rigidbody2D rb;


    //these are to set the values of action done;
    public float runSpeed;
    private float moveInput;
    public float jumpForce;


    // this is to check whether the player is on land or not!
    private bool isGrounded;


    //this is for the jump!
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatisGrounded;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isjumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //the whole block of code below is only for jump!
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisGrounded);


        //The block of code is to flip the character sprite:
        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        //this is for checking whether the player can jump or not!
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isjumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }


        //for continous long jump
        if(Input.GetKey(KeyCode.Space) && isjumping == true)
        {
           if(jumpTimeCounter > 0 )
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isjumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isjumping = false;
        }

        //for shoot;

    }

    private void FixedUpdate()
    {
        // the block of code below is for right and left movements!
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
    }
}
