using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float destroyDist = 8.0f;
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }



    }

    private void Update()
    {
        // Check if the player's position is above the platform and destroy it
        CheckDestroy();
    }

    private void CheckDestroy()
    {
        if (player == null)
        {
            // If the player reference is not set, find it by tag
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (player != null)
        {
            float playerY = player.transform.position.y;
            float platformY = transform.position.y;

            if (playerY > platformY + destroyDist)
            {
                // If the player is above the platform, destroy it
                Destroy(gameObject);
            }
        }
    }
}
