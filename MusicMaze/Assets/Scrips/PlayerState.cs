using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    // Existing variables...
    public float playerHP;
    public float maxHP;
    public bool isDead;

    public GameOverScreen gameOverScreen; // Reference to the GameOverScreen component

    void Start()
    {
        playerHP = maxHP;
        isDead = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerTakeDamage(30f);
        }

        if (playerHP <= 0 && !isDead)
        {
            isDead = true;
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

    public void playerTakeDamage(float dmg)
{
    playerHP -= dmg;
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
