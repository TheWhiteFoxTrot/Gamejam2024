using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float DamageAmount;
    public float LifeTime, GrowSpeed = 4f;
    private Vector3 TargetSize;
    public bool DestroyParent;


    void Start()
    {
        //Destroy(gameObject, LifeTime);

        TargetSize = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, TargetSize, GrowSpeed * Time.deltaTime);

        LifeTime -= Time.deltaTime;

        if(LifeTime <= 0)
        {
            TargetSize = Vector3.zero;
            if(transform.localScale.x == 0f)
            {
                Destroy(gameObject);

                if (DestroyParent)
                {
                    Destroy(transform.parent.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyMovement>().TakeDamage(DamageAmount);
        }
    }
}
