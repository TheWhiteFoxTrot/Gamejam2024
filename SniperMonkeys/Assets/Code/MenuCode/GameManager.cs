using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverCanvas;
    public Text timeSurvivedText;
    public Text highestLevelText;

    private float survivalTime = 0f;
    private int highestLevelReached = 1;
    private bool gameIsOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void AWAK()
    {
        gameOverCanvas.SetActive(false); // Hide Game Over screen initially
    }

    private void Update()
    {
        if (!gameIsOver)
        {
            survivalTime += Time.deltaTime; // Track survival time in seconds

            // Check player's health
            if (PlayerHealth.instance.CurrentHealth <= 0)
            {
                PlayerDied();
            }
        }
    }

    public void PlayerDied()
    {
        gameIsOver = true;
        gameOverCanvas.SetActive(true);

        // Display time survived and highest level reached
        timeSurvivedText.text = "Time Survived: " + Mathf.FloorToInt(survivalTime) + " seconds";
        highestLevelText.text = "Highest Level: " + highestLevelReached;
        
        // Pause the game
        Time.timeScale = 0f; // Stops game time
    }

    public void SetHighestLevel(int level)
    {
        if (level > highestLevelReached)
        {
            highestLevelReached = level;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset time scale to normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the scene
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2); // Load the main menu scene
    }
}
