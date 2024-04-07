using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // this script holds all the conditions and values related to the player
    // this is use to store what the player is currently holding or using
    public string playerState;
    public float playerHP;
    public float maxHP;
    public Boolean isDead;
    public int stateTracker = 0;
    public Conductor conductorRefrence;

    public GameOverScreen gameOverScreen; 

    List<string> states = new List<string> { "guitar", "trombone"};

    void Start()
    {
        playerState = states[stateTracker];
        stateTracker++;
    }

    // Update is called once per frame
    void Update()
    {
        // if player has no hp, they're dead so change boolean 
        if (playerHP == 0)
        {
            isDead = true;
        }

        if (playerHP > 100)
        {
            playerHP = 100;
        }




        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerState = states[stateTracker];
            stateTracker++;
            if (stateTracker == 2)
            {
                stateTracker = 0;

            }
            if (playerState == "guitar")
            {
                conductorRefrence.resetting("guitar");
            }

            else if(playerState == "trombone")
            {
                conductorRefrence.resetting("trombone");
            }
            
            }
        
    }
    //this function is used when we want the player to take dmg
    public void playerTakeDamage(float dmg)
    {
        playerHP -= dmg;
        // clamp pervent value to go below zero or over 100
        playerHP = Mathf.Clamp(playerHP, 0f, maxHP);
        // If health drops to zero and wasn't already at zero, trigger game over
    if (playerHP <= 0 && !isDead)
    {
        isDead = true;
        Debug.Log("Player has died. Game Over should trigger.");
        if (gameOverScreen != null)
        {
            gameOverScreen.OnGameOver();
        }
        else
        {
            Debug.LogError("GameOverScreen reference not set in PlayerState.");
        }
    }
    }


}
