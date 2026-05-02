using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 8f;
    public float jumpForce = 12f;
    
    [Header("Physics Detection")]
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask whatIsGround;
    
    [Header("Bomb Settings")]
    public GameObject bombPrefab;
    public Transform throwPoint;
    // You can now change these values directly in the Unity Inspector
    public Vector2 throwForce = new Vector2(7f, 10f);

    private Rigidbody2D rb;
    private Animator anim;
    private float moveDirection = 0f;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Topic A: Physics 2D Ground Detection
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        // Movement Input
        if (Input.GetKey(KeyCode.A)) moveDirection = -1f;
        else if (Input.GetKey(KeyCode.D)) moveDirection = 1f;
        else moveDirection = 0f;

        // Sprite Flipping
        if (moveDirection != 0)
            transform.localScale = new Vector3(moveDirection, 1, 1);

        // Jump Logic
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Topic C: Projectile Motion Trigger
        if (Input.GetKeyDown(KeyCode.F))
        {
            ThrowBomb();
        }

        // Animator Parameters
        anim.SetBool("isRunning", moveDirection != 0 && isGrounded);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.linearVelocity.y); 
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);
    }

    void ThrowBomb()
    {
        if (bombPrefab == null || throwPoint == null) return;

        GameObject bomb = Instantiate(bombPrefab, throwPoint.position, Quaternion.identity);
        Rigidbody2D bombRb = bomb.GetComponent<Rigidbody2D>();

        // Apply force based on facing direction and Inspector values
        float dir = transform.localScale.x;
        bombRb.AddForce(new Vector2(throwForce.x * dir, throwForce.y), ForceMode2D.Impulse);
    }
}