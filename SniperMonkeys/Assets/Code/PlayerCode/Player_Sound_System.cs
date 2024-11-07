using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sound_System : MonoBehaviour
{
    public PlayerHealth ph;

    [SerializeField] private AudioSource audioSource;

    public AudioClip[] hitSounds;
    public AudioClip[] startSounds;
    public AudioClip[] deathSounds;

    void Awake()
    {
        if (ph == null)
            ph = FindObjectOfType<PlayerHealth>();

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing on Player_Sound_System GameObject.");
            return;
        }

        // Play a starting sound when the game starts
        if (startSounds.Length > 0)
        {
            PlaySound(startSounds[Random.Range(0, startSounds.Length)]);
            Debug.Log("DEBUG: Playing Start Sound");
        }
    }

    void Update()
    {
        if (ph == null) return;

        if (ph.player_Hit_Sound)
        {
            PlayHitSound();
            ph.player_Hit_Sound = false;
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayHitSound()
    {
        if (hitSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, hitSounds.Length);
            PlaySound(hitSounds[randomIndex]);
            Debug.Log("DEBUG: Playing Hit Sound " + hitSounds[randomIndex].name);
        }
    }

    public void PlayDeathSound()
    {
        if (deathSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, deathSounds.Length);
            PlaySound(deathSounds[randomIndex]);
            Debug.Log("DEBUG: Playing Death Sound " + deathSounds[randomIndex].name);
        }
    }
}
