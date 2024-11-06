using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePickup : MonoBehaviour
{
    public int expValue;
    public float attractionDistance = 5f; // Distance within which XP moves toward the player
    public float attractionSpeed = 5f; // Speed at which the XP moves toward the player

    private Transform player;

    void Start()
    {
        // Locate the player GameObject (ensure the player is tagged as "Player")
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        // Calculate distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // If within attraction distance, move towards the player
        if (distanceToPlayer <= attractionDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, attractionSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            ExperienceLevelController.instance.GetExp(expValue);
            Destroy(gameObject); // Destroy the XP object after it's collected
        }
    }
}
