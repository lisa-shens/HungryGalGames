using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueberrySpawn : MonoBehaviour
{
    public GameObject blueberryPrefab;
    public float spawnInterval = 2.0f; // Adjust the interval between blueberry spawns
    private float nextSpawnTime = 0f;

    void Start()
    {
        // Start spawning blueberries immediately
        nextSpawnTime = Time.time;
    }

    void Update()
    {
        // Check if it's time to spawn a blueberry
        if (Time.time >= nextSpawnTime)
        {
            SpawnBlueberry();
            // Calculate the next spawn time
            nextSpawnTime = Time.time + spawnInterval;
        }

    }
    void SpawnBlueberry()
    {
        // Find all platforms with the "Platform" tag
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");

        if (platforms.Length == 0)
        {
            Debug.LogWarning("No platforms found with the 'Platform' tag. Blueberries won't spawn.");
            return;
        }

        // Select a random platform
        GameObject randomPlatform = platforms[Random.Range(0, platforms.Length)];

        // Get the center position of the selected platform
        Vector3 platformCenter = randomPlatform.transform.position;

        // Calculate the spawn position 2 units above the platform
        Vector3 spawnPosition = new Vector3(platformCenter.x, platformCenter.y + 1.0f, platformCenter.z);

        // Instantiate a blueberry at the calculated position
        Instantiate(blueberryPrefab, spawnPosition, Quaternion.identity);
    }

}
