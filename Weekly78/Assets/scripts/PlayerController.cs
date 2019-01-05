using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 5;
    public bool isGrounded;
    public int jumpPower = 250;

    private float moveX;

    private Rigidbody2D rb;
    private SpriteRenderer sp;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump"))
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

}
