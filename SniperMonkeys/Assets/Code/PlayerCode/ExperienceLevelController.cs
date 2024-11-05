using UnityEngine;
using UnityEngine.UI;

public class ExperienceLevelController : MonoBehaviour
{
    public static ExperienceLevelController instance; // Singleton instance

    [Header("Experience Settings")]
    public int currentExperience = 0; // Current experience points
    public int experienceToNextLevel = 100; // Experience required for the next level
    public int level = 1; // Current player level

    [Header("UI Elements")]
    public Slider experienceSlider; // Slider to represent experience visually
    public Text experienceText; // Text to show experience until next level
    public Text levelText; // Text to show current level

    [Header("Upgrade Screen Manager")]
    public UpgradeScreenManager upgradeScreenManager; // Reference to the upgrade screen manager

    private void Awake()
    {
        // Singleton pattern to ensure there's only one instance
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateExperienceUI(); // Initialize UI
    }

    public void GetExp(int amount)
    {
        currentExperience += amount;

        // Check if the player leveled up
        if (currentExperience >= experienceToNextLevel)
        {
            LevelUp();
        }

        // Update the UI elements
        UpdateExperienceUI();
    }

    private void LevelUp()
    {
        currentExperience -= experienceToNextLevel; // Deduct experience for leveling up
        level++; // Increment level
        experienceToNextLevel *= 2; // Double the required experience for next level

        // Debug log to check level-up trigger
        Debug.Log("Level Up! Current Level: " + level);

        // Update the level text
        levelText.text = "Level: " + level;

        // Show the upgrade screen and pause the game
        upgradeScreenManager.PauseGame(); // Show the upgrade panel
    }

    private void UpdateExperienceUI()
    {
        // Update the slider and text
        experienceSlider.maxValue = experienceToNextLevel;
        experienceSlider.value = currentExperience;
        experienceText.text = "Exp until next level: " + (experienceToNextLevel - currentExperience);
    }
}
