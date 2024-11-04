using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public int damagePerSecond = 10; // Damage to take per second when in contact with an enemy

    void Start()
    {
        // Initialize the player's health at the start
        currentHealth = maxHealth;
    }

    void UpdateHealthDisplay()
    {
        Debug.Log("Player Health: " + currentHealth);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Damage taken: " + damage);  // Add this line for debugging
        currentHealth -= Mathf.RoundToInt(damage);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        UpdateHealthDisplay();
    }


    private void Die()
    {
        Debug.Log("Player has died!");

        // Destroy the player game object
        Destroy(gameObject);

        // Alternatively, trigger other effects here (like a respawn or game over screen)
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the object we are colliding with is tagged as an "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Apply damage continuously each frame while in contact
            TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Player touched an enemy!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Player is no longer in contact with the enemy!");
        }
    }
}
