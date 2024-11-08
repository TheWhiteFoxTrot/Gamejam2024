using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Set the speed parameter based on the player's movement speed
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));

        // Flip the sprite based on the direction of movement
        if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = true; // Facing right
        }
        else if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = false; // Facing left
        }
    }
}
