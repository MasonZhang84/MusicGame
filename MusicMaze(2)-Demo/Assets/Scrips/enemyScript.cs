using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public Transform player;  // Reference to the player
    public float speed = 5.0f;  // Speed at which the enemy moves towards the player
    public GameObject gameOverScreen;  // Reference to the Game Over screen GameObject

    void Update()
    {
        // Check if the player has not been destroyed
        if (player != null)
        {
            // Move the enemy's position a step closer to the target (player).
            float step = speed * Time.deltaTime; // Calculate the distance to move per frame
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
{
    // Check for collision with the player
    if (collision.gameObject.CompareTag("Player"))
    {
        Destroy(collision.gameObject); // Destroys the player GameObject

        // Activate the Game Over screen and update it with the kill count before resetting kills
        if (gameOverScreen != null)
        {
            GameOverScreen gameOverScript = gameOverScreen.GetComponent<GameOverScreen>();
            if (gameOverScript != null)
            {
                gameOverScript.OnGameOver(); // Ensure this updates the UI first
            }
        }

        // Reset the kill count after updating the Game Over screen
        KillCounting.ResetKills(); 

        // Optionally, pause the game
        Time.timeScale = 0;
    }
}

}
