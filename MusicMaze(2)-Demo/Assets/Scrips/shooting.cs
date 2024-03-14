using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab; 

    public float  bulletForce = 30f; 

    void Update()
    {
        // if mouse 1, shoot a bullet
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }
    void shoot()
    {
        // new bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // get rigidbody 
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //apply direction and force
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
