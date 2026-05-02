using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private bool hasExploded = false;

    [Header("Settings")]
    public float autoDestructTime = 2f;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
        // Topic E: Air Resistance (Linear Drag)
        rb.linearDamping = 0.5f; 
    }

    void Start()
    {
        // This will destroy the bomb after 2 seconds if it hasn't hit anything.
        // It's like a fuse timer.
        Invoke("CheckAutoDestruct", autoDestructTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasExploded) return;

        // Topic A: Physics 2D Detection
        // If it hits the wall or ground, we cancel the auto-destruct and explode.
        if (collision.gameObject.CompareTag("Destructible") || collision.gameObject.CompareTag("Ground"))
        {
            CancelInvoke("CheckAutoDestruct"); 
            StartExplosion(collision.gameObject);
        }
    }

    void CheckAutoDestruct()
    {
        if (!hasExploded)
        {
            // If the bomb hasn't hit a wall yet, just make it disappear (or explode)
            StartExplosion(null); 
        }
    }

    void StartExplosion(GameObject target)
    {
        hasExploded = true;

        // Topic A: Unity Physics 2D - Stopping movement
        rb.linearVelocity = Vector2.zero;
        rb.isKinematic = true;

        // Play animation
        anim.SetTrigger("explode");

        // Destroy wall if target exists
        if (target != null && target.CompareTag("Destructible"))
        {
            Destroy(target);
        }

        // Final cleanup
        Destroy(gameObject, 0.5f); 
    }
}