using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 5;
    public bool isGrounded = true;
    [Range(1, 15)]
    public int jumpPower = 1;
    public bool canMove = true;


    private float moveX;

    public Rigidbody2D rb;
    private SpriteRenderer sr;
    public Animator anim;

    public static PlayerController instance;

    private void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(canMove)
        {
            Move();
        }

        HandleLayers();
        
    }

    private void Move()
    {
        //CONTROLS
        //ANIMATIONS
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            AudioManager.instance.PlaySound("jump");
            anim.SetTrigger("jump");
            Jump();
        }

        if (rb.velocity.x > 1f || rb.velocity.x < -1f)
        {
            anim.SetFloat("moveX", 1);
        }
        else
        {
            anim.SetFloat("moveX", 0);
        }

        if (isGrounded)
        {
            anim.SetBool("land", false);
        }

        if (rb.velocity.y < 0)
        {
            anim.SetBool("land", true);
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

    public void Jump()
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

    private void HandleLayers()
    {
        if (!isGrounded)
        {
            anim.SetLayerWeight(1, 1);
        } else
        {
            anim.SetLayerWeight(1, 0);
        }
    }

}
