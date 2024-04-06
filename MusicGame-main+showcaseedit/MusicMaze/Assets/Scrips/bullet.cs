using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public GameObject hitEffect; // this game obj stores the effect that will play once the bullet has hit an solid obj

    // when bullet hit somthing
    void OnCollisionEnter2D(Collision2D collision)
    {
        // create new effect hit effect obj and show the effect at location at which the bullet collided with somthing
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //distroy the effect after a while
        Destroy(effect, 0.5f);
        //distory bullet or self
        Destroy(gameObject);

        // if we hit an enemy
        if (collision.gameObject.tag == "Enemy")
        {
            // Increment the kill count
            KillCounting.AddKill();
            
            Destroy(collision.gameObject); // This line destroys the enemy GameObject
        }
    }
}
