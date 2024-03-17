using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rd;
    public Camera cam; 
    Vector2 movement;
    Vector2 mousePos;
    public PlayerState playerState; //refrence player state 


    void Update()
    {
        if (!playerState.isDead) {
            // get movment
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            // get mouse position 
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        
    }

    private void FixedUpdate()
    {
        if (!playerState.isDead)
            // move player
            rd.MovePosition(rd.position + movement * moveSpeed * Time.deltaTime);
            // move mouse
            // get direction
            Vector2 lookDir = mousePos - rd.position;
            // get rotation
            // note the -135 is the offset, change this if the sprite changes
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
            //apply rotation
            rd.rotation = angle;
        {




        }
    }
}
