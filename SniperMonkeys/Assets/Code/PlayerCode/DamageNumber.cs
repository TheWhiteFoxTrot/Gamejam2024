using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public TextMeshProUGUI DamageText;

    public float LifeTime;
    private float LifeCounter;

    public float floatSpeed = 1f;

    void Start()
    {
        LifeCounter = LifeTime;
    }

    void Update()
    {
        if(LifeCounter > 0)
        {
            LifeCounter -= Time.deltaTime;

            if(LifeCounter <= 0)
            {
                Destroy(gameObject);
            }
        }

        transform.position += Vector3.up * floatSpeed * Time.deltaTime;
    }

    public void Setup(int damageDisplay)
    {
        LifeCounter = LifeTime;

        DamageText.text = damageDisplay.ToString();
    }
}
