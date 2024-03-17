using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class KillCounting : MonoBehaviour
{
    public static int kills; 
    public TextMeshProUGUI killCounterText; 

    void Update()
{
    if (killCounterText != null)
    {
        killCounterText.text = "Kills: " + kills.ToString();
    }
    else
    {
        Debug.LogError("KillCounterText is not assigned or is disabled/destroyed");
    }
}


public static void AddKill()
{
    kills++; // Increment the kill count
    Debug.Log("Kill added. Total kills: " + kills); // Add this line for debugging
}


    public static void ResetKills()
    {
        kills = 0; // Reset the kill count
    }
}

