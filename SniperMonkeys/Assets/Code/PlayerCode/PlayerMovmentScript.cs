
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Player Movement Properties")]
    public float walkingSpeed;
    public float jumpingForce;
    public float swayMovement;

    private bool pickupInput;
    private float movementInput;
    private float verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        InputManager();
        MovementManager();
    }

    void InputManager()
    {
        // Fetch input for both axes
        movementInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Assuming pickupInput should trigger with another key (like 'E'), and 'Escape' is for pausing/quitting
        pickupInput = Input.GetKey(KeyCode.E);
    }

    void MovementManager()
    {
        // Update the velocity for both x and y directions
        rb.velocity = new Vector2(
            Mathf.Lerp(rb.velocity.x, movementInput * walkingSpeed, Time.deltaTime * swayMovement),
            Mathf.Lerp(rb.velocity.y, verticalInput * walkingSpeed, Time.deltaTime * swayMovement)
        );
    }
}
