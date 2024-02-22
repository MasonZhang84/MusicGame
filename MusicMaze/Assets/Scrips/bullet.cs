using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public GameObject hitEffect;


    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject); // This line destroys the enemy GameObject
        }
    }
}
