using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Get the arrow's velocity
        Vector2 velocity = rb.velocity;

        // Calculate the normalized direction of movement
        Vector2 normalizedDir = velocity.normalized;

        // Set the arrow's right direction to match the normalized direction
        transform.right = normalizedDir;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    PlayerController player = collision.gameObject.GetComponent<PlayerController>();
    //    if (player != null)
    //    {
    //        Destroy(player);
    //        // losing screen
    //    } else
    //    {
    //        return;
    //    }
    //}
}