using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 5;
    public bool isGrounded = true;
    [Range(1, 10)]
    public int jumpPower = 1;
    public bool canMove = true;


    private float moveX;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    public static PlayerController instance;

    private void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
        if (rb.velocity.x > 1f || rb.velocity.x < -1f)
        {
            anim.SetFloat("moveX", 1);
        }
        else
        {
            anim.SetFloat("moveX", 0);
        }



        //FLIP
        if (moveX < 0.0f)
        {
            sr.flipX = true;
        } 
        else if(moveX > 0.0f)
        {
            sr.flipX = false;
        }

        //PHYSICS
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpPower;
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
