using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class hp : MonoBehaviour
{

    public GameObject gameMaster;



    void OnCollisionEnter2D(Collision2D collision)
    {
        // if we hit a player
        if (collision.gameObject.tag == "Player")
        {
            GameObject gameMaster = GameObject.Find("GameMaster");
            PlayerState hpScript = gameMaster.GetComponent<PlayerState>();
            //heal player
            hpScript.playerHP = hpScript.playerHP + 35;
            Debug.Log("healing");
            Destroy(gameObject);
            }
        }
    
}
