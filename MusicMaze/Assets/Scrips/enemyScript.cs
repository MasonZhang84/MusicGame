using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyScript : MonoBehaviour
{
    private Transform player;
    public float speed = 5.0f;  // Speed at which the object will move towards the player
    public float detectionRange = 5f; // The maximum distance to check
    public PlayerState playerState; //refrence player state 
    private float immunityTime = 0.5f; // 0.5 seconds of immunity
    private float lastHitTime;
    private Rigidbody2D rb;
    public Animator animator;

    Vector3 velocity;
    Vector3 oneFrameAgo;


    void Start()
    {
        // Assuming the player has a tag "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        velocity = transform.position - oneFrameAgo;
        oneFrameAgo = transform.position;
        Debug.Log(velocity);
    }

    // Update is called once per frame
    void Update()
    {


        //animator.SetFloat("Horizontal", self.right);
        //animator.SetFloat("Vertical", self.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);

        Debug.Log(rb.velocity.y);

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);


        if (distanceToPlayer <= detectionRange)
        {   
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            animator.SetFloat("Speed", 1f);
            animator.SetFloat("Horizontal", player.position.x - transform.position.x);
            animator.SetFloat("Vertical", player.position.y - transform.position.y);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
            animator.SetFloat("Horizontal", 0f);
            animator.SetFloat("Vertical", 0f);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // if we hit a player
        if (collision.gameObject.tag == "Player")
        {
            // check if immunity period has passed
            if (Time.time > lastHitTime + immunityTime)
            {
                // player will take damage 
                playerState.playerTakeDamage(20f);
                // update the last hit time
                lastHitTime = Time.time;
            }
        }
    }
}
