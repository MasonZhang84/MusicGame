using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.PackageManager;
using System;

public class shooting : MonoBehaviour
{
    
    public TextMeshProUGUI sequenceText;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public AudioSource src;
    public AudioClip guitar;

    public float bulletForce = 30f;

    public double positionBPM;

    public AudioSource soundEffects;
    public AudioClip error;

    private bool isCooldown = false;

    public float shootingCooldown = 0.4f; // Cooldown in seconds between shots
    private float shootingTimer = 0f; // Timer to keep track when you can shoot again

    void Update()
    {
        shootingTimer -= Time.deltaTime;

        GameObject playerObj = GameObject.Find("Player");

        Conductor conductorComp = playerObj.GetComponent<Conductor>();

        positionBPM = conductorComp.songPositionInBeats;

        if (Input.GetMouseButtonDown(0) && !isCooldown)
        {
            double difference = positionBPM - Math.Round(positionBPM);
            if (Mathf.Abs((float)difference) <= 0.3f)
            {
                if (shootingTimer <= 0)
                {
                    shootingTimer = shootingCooldown;
                    shoot();
                }
            }
            else
            {
                soundEffects.clip = error;
                soundEffects.Play();
                StartCoroutine(Cooldown());
            }
        }
    }

    IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(1f);
        isCooldown = false;
    }


    void shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - transform.position).normalized;
        Vector3 shootPosition = transform.position + direction;

        GameObject bullet = Instantiate(bulletPrefab, shootPosition, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletForce; // bulletForce should be a constant value

        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

}
