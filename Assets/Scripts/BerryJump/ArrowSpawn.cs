using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float spawnWidth = 8;
    public float spawnRate = 1;
    public float arrowSpeed = 8.0f; // Adjust arrow speed as needed
    public float shootAngle = 250.0f; // Angle at which the arrow is shot
    public float rotationSpeed = 60;

    private float lastSpawnTime = 0;

    void Update()
    {
        if (lastSpawnTime + 1 / spawnRate < Time.time)
        {
            lastSpawnTime = Time.time;
            Vector3 spawnPosition = transform.position;
            spawnPosition += new Vector3(Random.Range(-spawnWidth, spawnWidth), 0, 0);
            GameObject arrow = Instantiate(arrowPrefab, spawnPosition, Quaternion.identity);

            // Calculate the initial velocity based on the desired angle and speed
            Vector2 direction = Quaternion.Euler(0, 0, shootAngle) * transform.right;
            transform.position = transform.position + new Vector3(direction.x, direction.y, 0) * arrowSpeed * Time.deltaTime;
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.forward);

            // Apply the initial velocity to the arrow
            arrow.GetComponent<Rigidbody2D>().velocity = direction.normalized * arrowSpeed;

            // Randomly flip the arrow sprite with a 50% chance
            if (Random.value > 0.5f)
            {
                // Flip the arrow sprite by changing the local scale on the y-axis
                arrow.transform.localScale = new Vector3(arrow.transform.localScale.x, -arrow.transform.localScale.y, arrow.transform.localScale.z);
            }
        }
    }
}
