using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public Transform player;  // Reference to the player
    public float speed = 5.0f;  // Speed at which the object will move towards the player
    public float maxDistance = 5f; // The maximum distance to check

    // Update is called once per frame
    void Update()
    {   
        // check distance from player
        float distanceToTarget = Vector3.Distance(transform.position, player.position);
        // if in range
        if (distanceToTarget <= maxDistance)
        {
            // Move our position a step closer to the target.
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject); // This line destroys the player GameObject
        }
    }
}
