using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public float speed, jumpforce;
    private Rigidbody2D rb;
    private Animator animator;
    private bool crouching = false;
    private BoxCollider2D collide;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collide = GetComponent <BoxCollider2D>();

    }

    // Update is called once 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            startcrouching();
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            stopcrouching();
        }



        if (rb.velocity.y > 0.1f)
        {
            animator.SetBool("jumping", true);
            animator.SetBool("falling", false);
        }
        if (rb.velocity.y < -0.1f)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", true);
        }

        if (rb.velocity.y >= -0.1f && rb.velocity.y <= 0.1f)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", false);
        }
    }

    private void jump()
    {
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Force);
        Debug.Log("Pulou");
    }
    private void startcrouching()
    {
        animator.SetBool("crouching", true);
        collide.offset = new Vector2 (collide.offset.x, -0.437f);
        collide.size = new Vector2(collide.size.x, 0.125f);


    }
    private void stopcrouching()
    {
        animator.SetBool("crouching", false);
        collide.offset = new Vector2(collide.offset.x, -0.294f);
        collide.size = new Vector2(collide.size.x, 0.410f);

    }
}

