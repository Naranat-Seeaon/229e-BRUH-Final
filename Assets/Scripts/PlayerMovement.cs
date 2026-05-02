using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpForce = 20f; // How high you jump
    
    private Rigidbody2D rb;
    private Animator anim;
    private float moveDirection = 0f;
    
    public bool isGrounded; // Visible in inspector for testing
    public Transform groundCheck; // Drag an empty GameObject here (put it at feet)
    public float checkRadius = 0.2f;
    public LayerMask whatIsGround; // Set this to your "Ground" layer

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 1. Ground Checking
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        // 2. Horizontal Movement
        if (Input.GetKey(KeyCode.A)) moveDirection = -1f;
        else if (Input.GetKey(KeyCode.D)) moveDirection = 1f;
        else moveDirection = 0f;

        if (moveDirection != 0) transform.localScale = new Vector3(moveDirection, 1, 1);

        // 3. Jumping (Only if on the ground)
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // --- ANIMATION LOGIC ---
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isRunning", moveDirection != 0 && isGrounded);

        // Send the vertical speed to the Animator
        // Positive = Going Up, Negative = Falling Down
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);
    }
}