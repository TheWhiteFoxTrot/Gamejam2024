using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeSword : MonoBehaviour
{
    public float RotateSpeed;
    public Transform holder, SwordToSpawn;
    public float TimeBetweenSpawn;
    private float SpawnCounter;

    void Start()
    {
        
    }

    void Update()
    {
        holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + (RotateSpeed * Time.deltaTime));

        SpawnCounter -= Time.deltaTime;

        if(SpawnCounter <= 0)
        {
            SpawnCounter = TimeBetweenSpawn;

            Instantiate(SwordToSpawn, SwordToSpawn.position, SwordToSpawn.rotation, holder).gameObject.SetActive(true);
        }
    }
}
