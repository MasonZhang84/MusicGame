using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Start()
{
    GameIsPaused = false;
    pauseMenuUI.SetActive(false);
}


    // Update is called once per frame
    void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        Debug.Log("ESC key was pressed. Current pause state: " + GameIsPaused);

        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
}


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // Make sure to link these in the On Click () of your buttons in the inspector
    public void LoadMenu()
    {
        // Load your main menu scene here
        // SceneManager.LoadScene("MainMenu");
        Resume(); // Optional: Unpause the game when going to the main menu
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
