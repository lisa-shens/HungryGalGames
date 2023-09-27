using System.Collections;
using UnityEngine;

public class PigMovemenet : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector2 targetPosition;
    public GameObject shotPig;
    public GameObject wholePig;
    private bool isWaiting = false;

    void Start()
    {
        targetPosition = GetRandomScreenPosition();
    }

    void Update()
    {
        if (!isWaiting)
        {
            // Move towards the target position.
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if the prefab has reached the target position.
            if ((Vector2)transform.position == targetPosition)
            {
                // Set a new random target position.
                targetPosition = GetRandomScreenPosition();
            }
        }
    }

    Vector2 GetRandomScreenPosition()
    {
        // Get a random position within the screen bounds.
        float x = Random.Range(0f, Screen.width);
        float y = Random.Range(0f, Screen.height);

        // Convert screen position to world position.
        return Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
    }

    public void onHit()
    {
        isWaiting = true;

        GameObject shotPigInstance = Instantiate(shotPig, transform.position, Quaternion.identity);

        StartCoroutine(WaitAndStartAgain(3f, shotPigInstance));
        
        //targetPosition = GetRandomScreenPosition();
        //Instantiate(wholePig, transform.position, Quaternion.identity);
        
    }

    IEnumerator WaitAndStartAgain(float waitTime, GameObject shotPigInstance)
    {
        yield return new WaitForSeconds(waitTime);

        Destroy(shotPigInstance);
        isWaiting = false;
        moveSpeed += 0.0005f;
        targetPosition = GetRandomScreenPosition();

    }
}

