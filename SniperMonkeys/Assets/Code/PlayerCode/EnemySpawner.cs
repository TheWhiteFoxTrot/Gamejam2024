using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyToSpawn;

    public float TimeToSpawn;
    private float SpawnCounter;

    //public float spawnOffset = 1f; // Distance to spawn enemies outside the camera view
    public Transform MinSpawn, MaxSpawn;

    private Transform target;

    private GameObject player;

    private float DespawnDistance;

    private List<GameObject> SpawnedEnemies = new List<GameObject>();

    public int CheckPerFrame;
    private int EnemyToCheck;

    public List<WaveInfo> waves;

    private int CurrentWave;

    private float WaveCounter;

    void Start()
    {
        SpawnCounter = TimeToSpawn;

        player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
        {
            target = player.GetComponent<Transform>();
        }

        DespawnDistance = Vector3.Distance(transform.position, MaxSpawn.position) + 4f;

        CurrentWave--;
        GoToNextWave();
    }

    void Update()
    {
        /*SpawnCounter -= Time.deltaTime;
        if (SpawnCounter <= 0)
        {
            SpawnCounter = TimeToSpawn;

            GameObject newEnemy = Instantiate(EnemyToSpawn, SelectSpawnPoint(), transform.rotation);

            SpawnedEnemies.Add(newEnemy);
        }*/

        if (PlayerHealth.instance.gameObject.activeSelf)
        {
            if(CurrentWave < waves.Count)
            {
                WaveCounter -= Time.deltaTime;
                if(WaveCounter <= 0)
                {
                    GoToNextWave();
                }

                SpawnCounter -= Time.deltaTime;
                if(SpawnCounter <= 0)
                {
                    SpawnCounter = waves[CurrentWave].TimeBetweenSpawns;

                    GameObject newEnemy = Instantiate(waves[CurrentWave].EnemyToSpawn, SelectSpawnPoint(), Quaternion.identity);

                    SpawnedEnemies.Add(newEnemy);
                }
            }
        }

        transform.position = target.position;

        int checkTarget = EnemyToCheck + CheckPerFrame;

        while (EnemyToCheck < checkTarget)
        {
            if (EnemyToCheck < SpawnedEnemies.Count)
            {
                if (SpawnedEnemies[EnemyToCheck] != null)
                {
                    if (Vector3.Distance(transform.position, SpawnedEnemies[EnemyToCheck].transform.position) > DespawnDistance)
                    {
                        Destroy(SpawnedEnemies[EnemyToCheck]);

                        SpawnedEnemies.RemoveAt(EnemyToCheck);
                        checkTarget--;
                    }
                    else
                    {
                        EnemyToCheck--;
                    }
                }
                else
                {
                    SpawnedEnemies.RemoveAt(EnemyToCheck);
                    checkTarget--;
                }
            }
            else
            {
                EnemyToCheck = 0;
                checkTarget = 0;
            }
        }
    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 SpawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f, 1f) > 0.5f;

        if(spawnVerticalEdge)
        {
            SpawnPoint.y = Random.Range(MinSpawn.position.y, MaxSpawn.position.y);

            if(Random.Range(0f, 1f) > 0.5f)
            {
                SpawnPoint.x = MaxSpawn.position.x;
            }
            else
            {
                SpawnPoint.x = MinSpawn.position.x;
            }
        }
        else
        {
            SpawnPoint.x = Random.Range(MinSpawn.position.x, MaxSpawn.position.x);

            if(Random.Range(0f, 1f) > 0.5f)
            {
                SpawnPoint.y = MaxSpawn.position.y;
            }
            else
            {
                SpawnPoint.y = MinSpawn.position.y;
            }
        }

        return SpawnPoint;
    }

    public void GoToNextWave()
    {
        CurrentWave++;

        if(CurrentWave >= waves.Count)
        {
            CurrentWave = waves.Count - 1;
        }

        WaveCounter = waves[CurrentWave].WaveLength;
        SpawnCounter = waves[CurrentWave].TimeBetweenSpawns;
    }
}

[System.Serializable]

public class WaveInfo
{
    public GameObject EnemyToSpawn;
    public float WaveLength = 10f;
    public float TimeBetweenSpawns = 1f;
}
