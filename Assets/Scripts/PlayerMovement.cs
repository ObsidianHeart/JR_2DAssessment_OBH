using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    public bool isGrounded;

    private float moveInput = 0f;
    private bool isRunning = false;

    // Double-tap detection for keyboard
    private float lastLeftKeyTime = -1f;
    private float lastRightKeyTime = -1f;
    private const float doubleTapThreshold = 0.3f;

    // Double-tap detection for onscreen
    private float lastLeftTapTime = -1f;
    private float lastRightTapTime = -1f;

    private bool facingRight = true; // Track facing direction

    private bool usingOnscreenInput = false; // Track if onscreen input is active

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Ground Check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Keyboard input
        float keyboardInput = Input.GetAxisRaw("Horizontal");

        // Only use keyboard input if onscreen input is not active
        if (!usingOnscreenInput)
        {
            // Double-tap detection for keyboard running
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (Time.time - lastLeftKeyTime < doubleTapThreshold)
                {
                    isRunning = true;
                }
                else
                {
                    isRunning = false;
                }
                lastLeftKeyTime = Time.time;
                moveInput = -1f;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (Time.time - lastRightKeyTime < doubleTapThreshold)
                {
                    isRunning = true;
                }
                else
                {
                    isRunning = false;
                }
                lastRightKeyTime = Time.time;
                moveInput = 1f;
            }
            else if (Mathf.Abs(keyboardInput) > 0.01f)
            {
                moveInput = keyboardInput;
            }
            else if (keyboardInput == 0)
            {
                moveInput = 0f;
                isRunning = false;
            }
        }

        float currentSpeed = isRunning ? runSpeed : moveSpeed;
        rb.linearVelocity = new Vector2(moveInput * currentSpeed, rb.linearVelocity.y);

        // Flip character based on movement direction
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        // Jumping (Keyboard)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // On-screen UI button functions (called by UI buttons)
    public void MoveLeft()
    {
        usingOnscreenInput = true;
        moveInput = -1f;
        if (Time.time - lastLeftTapTime < doubleTapThreshold)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        lastLeftTapTime = Time.time;

        if (facingRight)
            Flip();
    }

    public void MoveRight()
    {
        usingOnscreenInput = true;
        moveInput = 1f;
        if (Time.time - lastRightTapTime < doubleTapThreshold)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        lastRightTapTime = Time.time;

        if (!facingRight)
            Flip();
    }

    public void StopMoving()
    {
        usingOnscreenInput = false;
        moveInput = 0f;
        isRunning = false;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}

