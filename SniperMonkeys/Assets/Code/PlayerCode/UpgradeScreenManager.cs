using UnityEngine;
using UnityEngine.UI;

public class UpgradeScreenManager : MonoBehaviour
{
    public GameObject upgradePanel; // The panel that displays upgrade options
    public Button increaseHPButton; // Button for HP increase
    public Button increaseDamageButton; // Button for Damage increase
    public Button increaseSpeedButton; // Button for Speed increase

    private bool isGamePaused = false; // Flag to check if the game is paused

    void Start()
    {
        // Ensure the upgrade panel is hidden at the start
        upgradePanel.SetActive(false);

        // Add listeners to resume the game when any button is clicked
        increaseHPButton.onClick.AddListener(ResumeGame);
        increaseDamageButton.onClick.AddListener(ResumeGame);
        increaseSpeedButton.onClick.AddListener(ResumeGame);
    }

    public void PauseGame() // This will be called from ExperienceLevelController
    {
        isGamePaused = true; // Set pause flag
        Time.timeScale = 0f; // Pause the game
        upgradePanel.SetActive(true); // Show the upgrade panel
        Debug.Log("Game Paused. Upgrade Panel Activated."); // Debug log
    }

    public void ResumeGame()
    {
        isGamePaused = false; // Clear pause flag
        Time.timeScale = 1f; // Resume the game
        upgradePanel.SetActive(false); // Hide the upgrade panel
        Debug.Log("Game Resumed. Upgrade Panel Deactivated."); // Debug log
    }
}
