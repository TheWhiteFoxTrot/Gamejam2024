using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyToSpawn;
    public float TimeToSpawn;
    private float SpawnCounter;

    void Start()
    {
        SpawnCounter = TimeToSpawn;
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
        // Get the camera's viewport position in world space
        Camera mainCamera = Camera.main;
        Vector3 spawnPosition;

        // Calculate spawn position just outside the screen
        float screenWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float screenHeight = mainCamera.orthographicSize;

        // Randomly decide whether to spawn on the left, right, top, or bottom of the screen
        int spawnSide = Random.Range(0, 4); // 0 = left, 1 = right, 2 = top, 3 = bottom

        switch (spawnSide)
        {
            case 0: // Left
                spawnPosition = new Vector3(-screenWidth - 1, Random.Range(-screenHeight, screenHeight), 0);
                break;
            case 1: // Right
                spawnPosition = new Vector3(screenWidth + 1, Random.Range(-screenHeight, screenHeight), 0);
                break;
            case 2: // Top
                spawnPosition = new Vector3(Random.Range(-screenWidth, screenWidth), screenHeight + 1, 0);
                break;
            case 3: // Bottom
                spawnPosition = new Vector3(Random.Range(-screenWidth, screenWidth), -screenHeight - 1, 0);
                break;
            default:
                spawnPosition = transform.position; // Fallback (should never happen)
                break;
        }

        Instantiate(EnemyToSpawn, spawnPosition, Quaternion.identity);
    }
}
