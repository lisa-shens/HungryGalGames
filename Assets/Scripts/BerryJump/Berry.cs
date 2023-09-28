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
        // Increment berries score
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Destroy(gameObject);
            pointsManager.CollectBerry(); 
        }
    }
}
