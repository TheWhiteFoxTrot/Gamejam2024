using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D TheRigidBody;
    public float MoveSpeed, Damage;
    private GameObject player;
    private Transform target;

    public float HitWaitTime = 0.5f;
    private float HitCounter;

    public float health = 10f;

    public float KnockBackTime = 0.5f;
    private float KnockBackCounter;

    public bool Emnullshiting; // attacking
    public bool PissingSKibidy; // Getting hit
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            target = player.GetComponent<Transform>();
        }

        MoveSpeed = Random.Range(MoveSpeed * 0.8f,MoveSpeed * 1.2f);
    }

    private void Update()
    {
        if(KnockBackCounter > 0)
        {
            KnockBackCounter -= Time.deltaTime;

            if(MoveSpeed > 0)
            {
                MoveSpeed = -MoveSpeed * 2f;
            }

            if(KnockBackCounter <= 0)
            {
                MoveSpeed = Mathf.Abs(MoveSpeed * 0.5f);
            }
        }
    }

    void FixedUpdate()
    {
        TheRigidBody.velocity = (target.position - transform.position).normalized * MoveSpeed;

        if(HitCounter > 0)
        {
            HitCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerHealth>();

        if (player)
        {
            player.TakeDamage(Damage);

            HitCounter = HitWaitTime;
        }
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;
        PissingSKibidy = true;

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        DamageNumberController.instance.SpawnDamage(damageToTake, transform.position);
    }

    public void TakeDamage(float DamageToTake, bool ShouldKnockBack)
    {
        TakeDamage(DamageToTake);

        if(ShouldKnockBack)
        {
            KnockBackCounter = KnockBackTime;
        }
    }
    
}

