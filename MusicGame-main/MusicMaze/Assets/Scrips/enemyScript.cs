using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public Transform player;  // Reference to the player
    public float speed = 5.0f;  // Speed at which the object will move towards the player
    public float maxDistance = 5f; // The maximum distance to check
    public PlayerState playerState; // Reference to player state 

    void Update()
    {
        // If the player is not dead
        if (!playerState.isDead)
        {
            // Check distance from player
            float distanceToTarget = Vector3.Distance(transform.position, player.position);
            // If in range
            if (distanceToTarget <= maxDistance)
            {
                // Move our position a step closer to the target.
                float step = speed * Time.deltaTime; // Calculate distance to move
                // Move the enemy
                transform.position = Vector3.MoveTowards(transform.position, player.position, step);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If we hit the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player will take damage
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
