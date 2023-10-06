using UnityEngine;

public class Berry : MonoBehaviour
{
    private PointsManager pointsManager;

    private void Start()
    {
        pointsManager = GameObject.Find("PointsManager").GetComponent<PointsManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Increment 3 points for each berry collected
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Destroy(gameObject);
            pointsManager.updatePoints(3f); 
        }
    }
}
