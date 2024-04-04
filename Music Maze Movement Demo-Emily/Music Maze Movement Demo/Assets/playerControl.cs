using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator; 

    Vector2 movement;

    void Update()
    {
        // get movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // animation
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.X))
        {
             animator.SetFloat("Guitar", 1);
        }
        else
        {
            animator.SetFloat("Guitar", 0);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetFloat("Trumpet", 1);
        }
        else
        {
            animator.SetFloat("Trumpet", 0);
        }
    }

    private void FixedUpdate()
    {
        // move player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

}
