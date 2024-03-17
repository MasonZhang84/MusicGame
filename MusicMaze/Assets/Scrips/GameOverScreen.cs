using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; // This is necessary for TextMeshProUGUI
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI gameOverKillCountText; 

    public void Start()
    {
        // This line will deactivate the Game Over UI when the game starts
        gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Resume the game in case it was paused
        Time.timeScale = 1;
    }

    public void OnGameOver()
    {
        gameOverKillCountText.text = "Kills: " + KillCounting.kills.ToString(); // Assuming KillCounter.kills is your static kill count variable
        gameObject.SetActive(true); // Activate the Game Over screen
    }

    // Add this method to handle the quit action
    public void QuitGame()
    {
        // If we are running in a standalone build of the game
        #if UNITY_STANDALONE
        Application.Quit();
        #endif

        // If we are running in the editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
