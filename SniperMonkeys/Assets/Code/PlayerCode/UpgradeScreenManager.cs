using UnityEngine;
using UnityEngine.UI;

public class UpgradeScreenManager : MonoBehaviour
{
    public GameObject upgradePanel; // The panel that displays upgrade options
    public Button increaseHPButton; // Button for HP increase
    public Button increaseDamageButton; // Button for Damage increase
    public Button increaseSpeedButton; // Button for Speed increase

    [SerializeField] private PlayerHealth playerHealth; // Reference to PlayerHealth script
    private PlayerMovementScript playerMovement; // Reference to PlayerMovementScript
    [SerializeField] public EnemyDamager enemyDamager; // Reference to the EnemyDamager or attack damage source
    private bool isGamePaused = false; // Flag to check if the game is paused

    void Awake()
    {
        // Ensure the upgrade panel is hidden at the start
        upgradePanel.SetActive(false);

        // Add listeners to upgrade the player stats when any button is clicked
        increaseHPButton.onClick.AddListener(IncreaseHP);
        increaseDamageButton.onClick.AddListener(Dammige); 
        increaseSpeedButton.onClick.AddListener(IncreaseSpeed);

        increaseDamageButton.onClick.AddListener(() => Debug.Log("Button Pressed"));

        // Get references to the PlayerHealth, PlayerMovementScript, and EnemyDamager components
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerMovement = FindObjectOfType<PlayerMovementScript>();
    }

    // Increase Player HP
    private void IncreaseHP()
    {
        if (playerHealth != null)
        {
            playerHealth.MaxHealth += 20f; // Increase Max Health by 20 (example)
            playerHealth.CurrentHealth = playerHealth.MaxHealth; // Reset to max health after increase
            playerHealth.HealthSlider.maxValue = playerHealth.MaxHealth; // Update health slider
            playerHealth.HealthSlider.value = playerHealth.CurrentHealth; // Update slider value
            Debug.Log("Player HP increased: " + playerHealth.MaxHealth);
            ResumeGame();
        }
    }

    private void Dammige()
    {
        enemyDamager.DamageAmount += 1f;
        ResumeGame();
        Debug.Log("nigga");
    }

    // Increase Player Damage (if you have damage in your system)
    private void IncreaseDamage()
    {
        if (enemyDamager != null)
        {
            enemyDamager.DamageAmount += 1f;
            Debug.Log("Player Damage increased: " + enemyDamager.DamageAmount);
        }
        else
        {
            Debug.LogError("IncreaseDamage failed - EnemyDamager is null.");
        }
    }


    // Increase Player Speed
    private void IncreaseSpeed()
    {
        if (playerMovement != null)
        {
            playerMovement.walkingSpeed += 1f; // Increase speed by 1 (example)
            Debug.Log("Player Speed increased: " + playerMovement.walkingSpeed);
            ResumeGame();
        }
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
