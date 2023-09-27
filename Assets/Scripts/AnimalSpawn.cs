using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawn : MonoBehaviour
{
    public float spawnWidth = 1;
    public float spawnRate = 1;
    public GameObject animalPrefab;
    private float lastSpawnTime = 0;
    private float elapsedTime = 0f;

    void Update()
    {
       
        if (lastSpawnTime + 1 / spawnRate < Time.time)
        {
            elapsedTime += Time.deltaTime;
            lastSpawnTime = Time.time;
            Vector3 spawnPosition = transform.position;
            spawnPosition += new Vector3(Random.Range(-spawnWidth, spawnWidth), 0, 0);
            Instantiate(animalPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position - new Vector3(spawnWidth, 0, 0), transform.position + new Vector3(spawnWidth, 0, 0));
        Gizmos.DrawLine(transform.position - new Vector3(spawnWidth, 1, 0), transform.position - new Vector3(spawnWidth, -1, 0));
        Gizmos.DrawLine(transform.position + new Vector3(spawnWidth, 1, 0), transform.position + new Vector3(spawnWidth, -1, 0));
    }

}
