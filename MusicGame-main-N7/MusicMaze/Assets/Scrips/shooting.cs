using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.PackageManager;
using System;
using TMPro.EditorUtilities;

public class shooting : MonoBehaviour
{

    public TextMeshProUGUI sequenceText;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public AudioSource src;

    public float bulletForce = 30f;

    public double positionBPM;

    public AudioSource soundEffects;
    public AudioClip error;

    private bool isCooldown = false;

    public PlayerState playerStateRefrence;

    public float shootingCooldown = 0.4f; // Cooldown in seconds between shots
    private float shootingTimer = 0f; // Timer to keep track when you can shoot again
    private Rigidbody2D rb;

    public float moveSpeed = 20f;
    public float rollSpeed = 40f;
    private Vector2 movement;
    private bool isRolling = false;

    public float bubbleLife = 0.5f;
    public GameObject bubbleRefrence;

    public float aggroRange = 0.01f;

    public Boolean isActive = false;

    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        shootingTimer -= Time.deltaTime;

        GameObject playerObj = GameObject.Find("Player");

        Conductor conductorComp = playerObj.GetComponent<Conductor>();

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        positionBPM = conductorComp.songPositionInBeats;

        // Find all enemies with the "Enemy" tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy <= aggroRange && isRolling)
            {
                // Enemy is within aggro range, destroy it
                Destroy(enemy);
            }

        }


        if (Input.GetMouseButtonDown(0) && !isCooldown && playerStateRefrence.playerState == "guitar")
        {
            double difference = positionBPM - Math.Round(positionBPM);
            if (Mathf.Abs((float)difference) <= 0.4f)
            {
                if (shootingTimer <= 0)
                {
                    animator.SetFloat("Guitar", 1f);
                    Invoke("Delaytrumpet", 1f);
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


        if (Input.GetMouseButtonDown(0) && !isCooldown && playerStateRefrence.playerState == "trombone")
        {
            double difference = positionBPM - Math.Round(positionBPM);
            if (Mathf.Abs((float)difference) <= 0.4f)
            {
                if (shootingTimer <= 0)
                {
                    animator.SetFloat("Trumpet", 1f);
                    shootingTimer = shootingCooldown;
                    StartCoroutine(Roll());
                    StartCoroutine(ControlRendering());
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

    void FixedUpdate()
    {
        // Movement
        if (!isRolling)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(1.7f);
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


    IEnumerator Roll()
    {
        isRolling = true;
        float rollTime = 0.5f; // Roll duration
        float startRoll = Time.time;

        

        while (Time.time < startRoll + rollTime)
        {
            // Interpolate the roll speed from initial to zero
            float t = (Time.time - startRoll) / rollTime;
            float currentRollSpeed = Mathf.Lerp(rollSpeed, 0f, t);

            rb.MovePosition(rb.position + movement * currentRollSpeed * Time.fixedDeltaTime);
            yield return null;
        }

        isRolling = false;
    }

    IEnumerator ControlRendering()
    {   
        Renderer renderer = bubbleRefrence.GetComponent<Renderer>();
        // Enable rendering
        renderer.enabled = true;

        // Wait for the specified delay time
        yield return new WaitForSeconds(bubbleLife);

        // Disable rendering
        renderer.enabled = false;
        animator.SetFloat("Trumpet", 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the bubble is active and the collider belongs to an enemy
        if (isActive && other.CompareTag("Enemy"))
        {
            // Destroy the enemy GameObject
            Destroy(other.gameObject);
        }
    }

    void Delaytrumpet() {

        animator.SetFloat("Guitar", 0f);

    }
}

