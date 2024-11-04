using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MoveSpeed;
    private Vector2 MoveInput;
    public Rigidbody2D rb2d;


    void Update()
    {
        MoveInput.x = Input.GetAxisRaw("Horizontal");
        MoveInput.y = Input.GetAxisRaw("Vertical");

        MoveInput.Normalize();

        rb2d.velocity = MoveInput * MoveSpeed;
    }
}
