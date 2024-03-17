using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject hitEffect; // This game obj stores the effect that will play once the bullet has hit a solid obj

    // When bullet hit something
    void OnCollisionEnter2D(Collision2D collision)
    {
        // If we hit an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Increment the kill count
            KillCounting.AddKill();

            // Destroy the enemy GameObject
            Destroy(collision.gameObject);
        }

        // Create new effect hit effect obj and show the effect at the location at which the bullet collided with something
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        
        // Destroy the effect after a while
        Destroy(effect, 0.5f);
        
        // Destroy bullet or self
        Destroy(gameObject);
    }
}
