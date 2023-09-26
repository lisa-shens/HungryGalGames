//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerShooting : MonoBehaviour
//{
//    public GameObject arrowPrefab; // Assign the arrow prefab in the Inspector
//    public Transform spawnPoint; // The spawn point for arrows
//    public float arrowSpeed = 10.0f; // Adjust arrow speed as needed
//    public float shootAngle = 330.0f; // Angle at which the arrow is shot
//    public float horizontalOffset = 1.0f; // Horizontal offset to shoot the arrow to the right

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            ShootArrow();
//        }
//    }

//    void ShootArrow()
//    {
//        // Create an arrow clone at the spawn point
//        GameObject arrow = Instantiate(arrowPrefab, spawnPoint.position, Quaternion.identity);

//        // Calculate the initial velocity based on the desired angle and speed
//        Vector2 direction = Quaternion.Euler(0, 0, shootAngle) * transform.right;

//        // Apply the horizontal offset to the arrow's initial position
//        Vector3 spawnPosition = spawnPoint.position + Vector3.right * horizontalOffset;

//        // Apply the initial velocity to the arrow
//        arrow.GetComponent<Rigidbody2D>().velocity = direction.normalized * arrowSpeed;

//        // Set the arrow's position to the adjusted spawn position
//        arrow.transform.position = spawnPosition;
//    }
//}
