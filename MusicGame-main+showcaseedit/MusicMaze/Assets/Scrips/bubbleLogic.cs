using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleLogic : MonoBehaviour
{
    public float activeDuration = 0.5f; // The duration the kill bubble is active (in seconds)

    public bool isActive = false; // Flag to track if the bubble is currently active

    private void OnTriggerEnter(Collider other)
    {
        // Check if the bubble is active and the collider belongs to an enemy
        if (isActive && other.CompareTag("Enemy"))
        {
            // Destroy the enemy GameObject
            Destroy(other.gameObject);
        }
    }
}
