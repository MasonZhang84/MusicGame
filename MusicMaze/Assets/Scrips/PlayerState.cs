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
    }


}
