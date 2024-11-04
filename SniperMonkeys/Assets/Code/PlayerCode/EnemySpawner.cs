using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyToSpawn;
    public float TimeToSpawn;
    public float spawnOffset = 1f; // Distance to spawn enemies outside the camera view
    private float SpawnCounter;
    private Transform player;

    void Start()
    {
        SpawnCounter = TimeToSpawn;
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player by tag
    }

    void Update()
    {
        SpawnCounter -= Time.deltaTime;
        if (SpawnCounter <= 0)
        {
            SpawnCounter = TimeToSpawn;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (player != null) // Ensure the player reference is valid
        {
            // Get the camera's viewport size in world units
            Camera mainCamera = Camera.main;
            float screenWidth = mainCamera.orthographicSize * mainCamera.aspect;
            float screenHeight = mainCamera.orthographicSize;

            // Randomly decide to spawn on one of the four sides
            int spawnSide = Random.Range(0, 4);
            Vector3 spawnPosition;

            switch (spawnSide)
            {
                case 0: // Left
                    spawnPosition = new Vector3(player.position.x - screenWidth - spawnOffset, Random.Range(player.position.y - screenHeight, player.position.y + screenHeight), 0);
                    break;
                case 1: // Right
                    spawnPosition = new Vector3(player.position.x + screenWidth + spawnOffset, Random.Range(player.position.y - screenHeight, player.position.y + screenHeight), 0);
                    break;
                case 2: // Top
                    spawnPosition = new Vector3(Random.Range(player.position.x - screenWidth, player.position.x + screenWidth), player.position.y + screenHeight + spawnOffset, 0);
                    break;
                case 3: // Bottom
                    spawnPosition = new Vector3(Random.Range(player.position.x - screenWidth, player.position.x + screenWidth), player.position.y - screenHeight - spawnOffset, 0);
                    break;
                default:
                    spawnPosition = transform.position; // Fallback (should never happen)
                    break;
            }

            // Instantiate the enemy at the calculated spawn position
            Instantiate(EnemyToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
