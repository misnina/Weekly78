using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 5;
    public bool isGrounded = true;
    public int jumpPower = 350;
    public bool canMove = true;

    private float moveX;

    private Rigidbody2D rb;
    private SpriteRenderer sp;

    public static PlayerController instance;

    private void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(canMove)
        {
            Move();
        }
        
    }

    private void Move()
    {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }


        //ANIMATIONS

        //FLIP
        if (moveX < 0.0f)
        {
            sp.flipX = true;
        } 
        else if(moveX > 0.0f)
        {
            sp.flipX = false;
        }

        //PHYSICS
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
    }

    private void Jump()
    {
        //JUMPING CODE
        rb.AddForce(Vector2.up * jumpPower);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
