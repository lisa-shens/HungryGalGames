using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offsetY;

    private void LateUpdate()
    {
        Vector3 position = transform.position;
        position.y = player.position.y + offsetY;
        transform.position = position;
    }
}
