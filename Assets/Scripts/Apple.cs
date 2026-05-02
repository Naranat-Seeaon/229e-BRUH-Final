using UnityEngine;

public class AppleItem : MonoBehaviour
{
    public AudioClip collectSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // เล่นเสียง ณ ตำแหน่งของแอปเปิล
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            FindFirstObjectByType<UiManager>().AddApple();
            Destroy(gameObject);
        }
    }
}