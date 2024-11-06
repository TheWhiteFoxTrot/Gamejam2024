using UnityEngine;

public class ExperienceDropOnDeath : MonoBehaviour
{
    public GameObject experiencePickupPrefab; // Reference to the Experience Pickup prefab
    public int experienceAmount = 10; // Amount of experience this enemy should drop

    private void OnDestroy()
    {
        // Instantiate the experience pickup at the enemy's position
        if (experiencePickupPrefab != null)
        {
            GameObject expPickup = Instantiate(experiencePickupPrefab, transform.position, Quaternion.identity);
            
            // Set the experience value of the pickup
            ExperiencePickup expScript = expPickup.GetComponent<ExperiencePickup>();
            if (expScript != null)
            {
                expScript.expValue = experienceAmount;
            }
        }
    }
}
