using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject platformPrefab;

    public int numberOfPlatforms = 120;
    public float levelWidth = 5.0f;
    public float minY = -.2f;
    public float maxY = 1.5f;
    public float spacing = 1.0f; // Adjust this to set the vertical spacing between platforms.

    // Use this for initialization
    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY) + spacing; // Add spacing
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
