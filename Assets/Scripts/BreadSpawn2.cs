using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadSpawn2 : MonoBehaviour
{
    public float spawnWidth = 1;
    public GameObject breadPrefab;

    public void SpawnBread2()
    {
        // This is a simple timer structure that executes every 1/spawnRate seconds. 
        // This means it spawns spawnRate items every second.
        
        Vector3 spawnPosition = transform.position;
        spawnPosition += new Vector3(UnityEngine.Random.Range(-spawnWidth, spawnWidth), 0, 0);

        // Instantiate the TrashItemPrefab and set its SpriteRenderer's sprite
        Instantiate(breadPrefab, spawnPosition, Quaternion.identity);

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position - new Vector3(spawnWidth, 0, 0), transform.position + new Vector3(spawnWidth, 0, 0));
        Gizmos.DrawLine(transform.position - new Vector3(spawnWidth, 1, 0), transform.position - new Vector3(spawnWidth, -1, 0));
        Gizmos.DrawLine(transform.position + new Vector3(spawnWidth, 1, 0), transform.position + new Vector3(spawnWidth, -1, 0));
    }
}