using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heathBar : MonoBehaviour
{

    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    private float lerpSpeed = 0.005f;

    public PlayerState playerState;

    void Start()
    {   
        // update hp bar on start up 
        UpdateHealthUI();
    }

    void Update()
    {
        // if the main hp bar(red) is not = to hp 
        if (healthSlider.value != playerState.playerHP)
        {   
            // update the red hp bar to reflect player hp
            healthSlider.value = playerState.playerHP;
            UpdateHealthUI();
        }
        
        // if ease bar (yellow) is not = to hp
        if (easeHealthSlider.value != playerState.playerHP)
        {
            // ease into the value, slowly the yellow bar will decay into the red bar
            // this is mostly for visual flar 
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, playerState.playerHP, lerpSpeed);
            UpdateHealthUI();
        }

        
    }

    void UpdateHealthUI()
    {   
        // update relevant values 
        healthSlider.value = playerState.playerHP;
    }
}
