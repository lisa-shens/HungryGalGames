using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Rigidbody2D rb;
    public float lifetime = 3.0f;
    public float rotationSpeed = 40;
    public float speed = 1;
    Vector2 direction = new Vector2();

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Destroy the weapon object after the specified lifetime.
        Destroy(gameObject, lifetime);
        direction = new Vector2(0, -1);
        // normalize direction so it does not impact the travel speed
        direction.Normalize();
    }

    private void FixedUpdate()
    {
        
        transform.position = transform.position + new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Animal animal = collision.gameObject.GetComponent<Animal>();
        if (animal != null)
        {
            animal.onHit();
        }
        Destroy(gameObject);
    }
}
