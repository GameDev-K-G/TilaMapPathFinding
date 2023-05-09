using UnityEngine;
 
public class RunAwayFromPlayer : MonoBehaviour
{
    public float speed = -5f; // Speed at which the object moves away from the player (make sure this is negative)
    public Transform player; // Reference to the player's Transform component
    private Rigidbody2D rb; // Reference to the object's Rigidbody2D component
 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
 
    private void FixedUpdate()
    {
        // Calculate the direction from the object to the player
        Vector2 direction = transform.position - player.position;
        direction.Normalize();
 
        // Move the object away from the player
        rb.velocity = direction * -speed;
    }
}