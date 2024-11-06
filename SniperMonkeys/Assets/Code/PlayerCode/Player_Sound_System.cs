using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sound_System : MonoBehaviour
{
    public PlayerHealth ph;

    [SerializeField] public AudioSource audioSource;

    public AudioClip[] hitSounds;
    public AudioClip[] startSounds;
    public AudioClip[] deathSounds;

    void Awake()
    {
        if (ph == null)
            ph = GetComponent<PlayerHealth>();

        audioSource = GetComponent<AudioSource>();

        // Play a starting sound when the game starts, if applicable
        if (startSounds.Length > 0)
        {
            PlaySound(startSounds[Random.Range(0, startSounds.Length)]);
        }
    }

    void Update()
    {
        if (ph.player_Hit_Sound)
        {
            PlayHitSound();
            ph.player_Hit_Sound = false; // Reset to prevent retrigger
        }
        if (ph.player_Death_Sound)
        {
            PlayDeathSound();
            ph.player_Death_Sound = false;
        }
    }

    // Play a single sound, stopping any currently playing sound
    private void PlaySound(AudioClip clip)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // Stop the current sound
        }
        audioSource.clip = clip;
        audioSource.Play();
    }

    // Randomly selects and plays one hit sound
    public void PlayHitSound()
    {
        if (hitSounds.Length > 0)
        {
           
            int randomIndex = Random.Range(0, hitSounds.Length); // Select random clip
            PlaySound(hitSounds[randomIndex]);
            Debug.Log("DEBUG: Playing Hit Sound " + hitSounds[randomIndex].name);
        }
    }

    // Plays a random death sound
    public void PlayDeathSound()
    {
        if (deathSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, deathSounds.Length); // Select random clip
            PlaySound(deathSounds[randomIndex]);
            Debug.Log("DEBUG: Playing Death Sound " + deathSounds[randomIndex].name);
        }
    }
}
