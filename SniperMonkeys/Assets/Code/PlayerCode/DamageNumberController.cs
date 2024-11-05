using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController instance;

    void Start()
    {
        instance = this;   
    }

    public DamageNumber NumberToSpawn;
    public Transform NumberCanvas;

    void Update()
    {
        
    }

    public void SpawnDamage(float damageAmount, Vector3 location)
    {
        int rounded = Mathf.RoundToInt(damageAmount);

        DamageNumber newDamage = Instantiate(NumberToSpawn, location, Quaternion.identity, NumberCanvas);

        newDamage.Setup(rounded);
        newDamage.gameObject.SetActive(true);
    }
}
