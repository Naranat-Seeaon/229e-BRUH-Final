using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Topic A: Trigger detection to "pick up" the item
        if (other.CompareTag("Player"))
        {
            // Tell the Game Manager to add a point
            GameManager.instance.AddScore();
            
            // Remove the fruit from the map
            Destroy(gameObject);
        }
    }
}