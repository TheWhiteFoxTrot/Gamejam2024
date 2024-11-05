using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public float CurrentHealth, MaxHealth;
    public Slider HealthSlider;

    private void Awake()
    {
        instance = this;

        HealthSlider.maxValue = MaxHealth;
        HealthSlider.value = CurrentHealth;
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);

        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage(10);
            Debug.Log(collision.collider.name);
        }
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        HealthSlider.value = CurrentHealth;
    }
}
