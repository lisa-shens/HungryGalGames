using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform spawnPoint;
    public float platformSpacing = 2.0f; // Distance between platforms
    public int maxPlatforms = 10; // Maximum number of platforms to keep active
    public float destroyHeight = -10.0f; // Height at which platforms are destroyed

    private GameObject[] activePlatforms;
    private int platformIndex = 0;

    private void Start()
    {
        activePlatforms = new GameObject[maxPlatforms];

        SpawnInitialPlatforms();
    }

    private void Update()
    {
        // Check if the top platform is below the destroyHeight
        if (activePlatforms[platformIndex].transform.position.y < destroyHeight)
        {
            RecyclePlatform();
        }
    }

    private void SpawnInitialPlatforms()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-5.0f, 5.0f), // X position range
            spawnPoint.position.y + platformSpacing * platformIndex, // Y position
            spawnPoint.position.z // Z position (should be the same as spawnPoint)
        );

        GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        activePlatforms[platformIndex] = newPlatform;

        platformIndex++;
        if (platformIndex >= maxPlatforms)
        {
            platformIndex = 0;
        }
    }

    private void RecyclePlatform()
    {
        Destroy(activePlatforms[platformIndex]);
        SpawnPlatform();
    }
}
