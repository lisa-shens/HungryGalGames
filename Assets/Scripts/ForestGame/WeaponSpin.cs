using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpin : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Speed of rotation in degrees per second

    void Update()
    {
        // Rotate the GameObject around its Z-axis at the specified speed
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
