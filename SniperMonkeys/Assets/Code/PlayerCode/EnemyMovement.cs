using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D TheRigidBody;
    public float MoveSpeed, Damage;
    private Transform target;

    void Start()
    {
        target = FindObjectOfType<PlayerMovementScript>().transform;

        MoveSpeed = Random.Range(0.7f, 1.4f);
    }

    private void FixedUpdate()
    {
        TheRigidBody.velocity = (target.position - transform.position).normalized * MoveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerHealth.instance.tag == "Player")
        {
            PlayerHealth.instance.TakeDamage(Damage);
        }
    }
}

