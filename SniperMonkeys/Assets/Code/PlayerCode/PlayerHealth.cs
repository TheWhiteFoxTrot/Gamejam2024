using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public float CurrentHealth, MaxHealth;
    [HideInInspector] public bool player_Hit_Sound;
    [HideInInspector] public bool player_Death_Sound;
    public Slider HealthSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple PlayerHealth instances detected. Destroying duplicate.");
            Destroy(gameObject);
            return;
        }

        HealthSlider.maxValue = MaxHealth;
        HealthSlider.value = MaxHealth;
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
        HealthSlider.value = CurrentHealth; // Ensure health slider matches initial health
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with: " + collision.collider.name);

        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage(10);
            Debug.Log("Hit registered from: " + collision.collider.name);
        }
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        HealthSlider.value = CurrentHealth;

        if (CurrentHealth <= 0)
        {
            player_Death_Sound = true;
            gameObject.SetActive(false); // Disable GameObject on death
            Debug.Log("Player has died.");
        }
        else
        {
            player_Hit_Sound = true;
        }
    }
}
