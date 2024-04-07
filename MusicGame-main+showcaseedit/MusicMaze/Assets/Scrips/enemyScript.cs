using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyScript : MonoBehaviour
{
    public Transform player;  // Reference to the player
    public float speed = 5.0f;  // Speed at which the object will move towards the player
    public float maxDistance = 5f; // The maximum distance to check
    public PlayerState playerState; //refrence player state 
    

    // Update is called once per frame
    void Update()
    {   
        // if the player is not dead
        if (!playerState.isDead)
        {
            // check distance from player
            float distanceToTarget = Vector3.Distance(transform.position, player.position);
            // if in range
            if (distanceToTarget <= maxDistance)
            {
                // Move our position a step closer to the target.
                float step = speed * Time.deltaTime; // calculate distance to move
                                                     //move the enemy
                transform.position = Vector3.MoveTowards(transform.position, player.position, step);
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {   
        // if we hit a player
        if (collision.gameObject.tag == "Player")
        {   
            //player will take dmg 
            playerState.playerTakeDamage(30f);

            // Check if the player is dead after taking damage
            if (playerState.isDead)
            {
                // Here you can handle what happens when the player dies, for example:
                // Disable the enemy
                this.enabled = false;
                // Or destroy the enemy game object if needed
                // Destroy(gameObject);
            }
        }
    }
}
