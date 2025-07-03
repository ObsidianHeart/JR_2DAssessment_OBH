using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private PlayerMovement playerMovement;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        bool isMoving = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        animator.SetBool("isMoving", isMoving);

        bool isJumping = !playerMovement.isGrounded;
        animator.SetBool("isJumping", isJumping);

        // Use PlayerMovement's isRunning state
        bool isRunning = playerMovement.IsRunning();
        animator.SetBool("isRunning", isRunning && isMoving);
    }
}

