using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    public float rollSpeed = 10f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private bool isRolling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Roll());
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
}
