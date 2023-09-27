using UnityEngine;

public class Berry : MonoBehaviour
{
    public PointsManager pointsManager; // Reference to the PointsManager

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            // Destroy the berry when touched by the player
            Destroy(gameObject);

            // Add points to the PointsManager
            pointsManager.AddPoints(3);
        }
    }
}
