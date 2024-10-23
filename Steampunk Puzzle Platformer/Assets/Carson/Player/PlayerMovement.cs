using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;                // Movement speed
    [SerializeField] private float jumpPower;            // Jumping force
    [SerializeField] private float coyoteTime;           // Time allowed for coyote jump
    [SerializeField] private int extraJumps;             // Additional jumps allowed
    [SerializeField] private float wallJumpX;            // Horizontal wall jump force
    [SerializeField] private float wallJumpY;            // Vertical wall jump force
    [SerializeField] private float wallSlideSpeed = 2f;  // Speed at which player slides down the wall
    [SerializeField] private LayerMask groundLayer;      // Ground detection
    [SerializeField] private LayerMask wallLayer;        // Wall detection

    private Rigidbody2D body;
    private CapsuleCollider2D capCollider;
    private float coyoteCounter;
    private int jumpCounter;
    private bool isJumping;
    private bool hasWallJumped;
    private float wallJumpCooldown;
    private float horizontalInput;

    private void Awake()
    {
        // Grab references
        body = GetComponent<Rigidbody2D>();
        capCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Flip character based on movement direction
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // Decrease wall jump cooldown over time
        wallJumpCooldown -= Time.deltaTime;

        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space) && CanJump())
            Jump();

        // Adjustable jump height if space is released mid-air
        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);

        // Wall sliding behavior
        if (onWall() && !isGrounded() && horizontalInput != 0 && wallJumpCooldown <= 0)
        {
            if (body.velocity.y < 0)
            {
                // Apply wall sliding effect if player is moving down the wall
                body.velocity = new Vector2(body.velocity.x, -wallSlideSpeed);
            }
        }
        else
        {
            // Move player with horizontal input
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (isGrounded())
            {
                ResetJumpState();  // Reset states when grounded
            }
            else
            {
                coyoteCounter -= Time.deltaTime; // Decrease coyote time
            }
        }

        // Reset wall jump flag when sufficiently away from the wall
        if (!onWall() && wallJumpCooldown <= 0)
        {
            hasWallJumped = false;
        }
    }

    private bool CanJump()
    {
        // Allow jump if coyote time > 0, has extra jumps, or wall jump is available
        return isGrounded() || coyoteCounter > 0 || jumpCounter > 0 || (onWall() && !hasWallJumped);
    }

    private void Jump()
    {
        // Regular jump or coyote jump
        if (isGrounded() || coyoteCounter > 0)
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower); // Set vertical velocity directly for consistent jumps
            coyoteCounter = 0; // Reset coyote jump
            isJumping = true;
        }
        else if (jumpCounter > 0) // Extra jumps
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower); // Set vertical velocity directly
            jumpCounter--; // Use up an extra jump
        }
        // Wall jump if touching the wall and not recently wall jumped
        else if (onWall() && !hasWallJumped)
        {
            WallJump();
        }
    }

    private void WallJump()
    {
        // Perform a wall jump with horizontal and vertical force
        body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpX, wallJumpY);

        hasWallJumped = true; // Mark that a wall jump was performed
        wallJumpCooldown = 0.2f; // Set cooldown to prevent getting stuck to the wall
    }

    private void ResetJumpState()
    {
        // Reset jump-related states when grounded
        coyoteCounter = coyoteTime;
        jumpCounter = extraJumps;
        hasWallJumped = false;
        isJumping = false;
    }

    private bool isGrounded()
    {
        // Check if the player is grounded using a BoxCast
        RaycastHit2D raycastHit = Physics2D.BoxCast(capCollider.bounds.center, capCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        // Check if the player is touching a wall
        RaycastHit2D raycastHit = Physics2D.BoxCast(capCollider.bounds.center, capCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        // Player can attack if not moving and grounded
        return horizontalInput == 0 && isGrounded() && !onWall();
    }
}
