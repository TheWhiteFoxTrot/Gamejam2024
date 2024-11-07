using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundSystem : MonoBehaviour
{
    // Reference to the EnemyMovement script to check if the enemy is hit
    private EnemyMovement enemyMovement;
    private AudioSource audioSource;

    // List of possible sounds
    public List<AudioClip> enemySounds;

    // Timer range for random sound playback
    public float minSoundInterval = 1f;
    public float maxSoundInterval = 6f;
    private float nextSoundTime;

    void Start()
    {
        // Initialize references
        enemyMovement = GetComponent<EnemyMovement>();
        audioSource = GetComponent<AudioSource>();

        // Set initial random time for the next sound
        nextSoundTime = Time.time + Random.Range(minSoundInterval, maxSoundInterval);
    }

    void Update()
    {
        // Play random sound at intervals
        if (Time.time >= nextSoundTime)
        {
            PlayRandomSound();
            nextSoundTime = Time.time + Random.Range(minSoundInterval, maxSoundInterval);
        }

        // Check if the enemy is hit and play a sound if so
        if (enemyMovement.PissingSKibidy)
        {
            PlayHitSound();
            enemyMovement.PissingSKibidy = false; // Reset hit status after playing the sound
        }
    }

    // Play a random sound from the list
    private void PlayRandomSound()
    {
        if (enemySounds.Count > 0 && audioSource != null)
        {
            int randomIndex = Random.Range(0, enemySounds.Count);
            audioSource.PlayOneShot(enemySounds[randomIndex]);
        }
    }

    // Play sound specifically when hit
    private void PlayHitSound()
    {
        if (enemySounds.Count > 0 && audioSource != null)
        {
            audioSource.PlayOneShot(enemySounds[0]); // Example: plays the first sound in the list for "hit"
        }
    }
}
