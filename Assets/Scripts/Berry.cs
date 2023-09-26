using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to do: add points to a static berry counter


public class Berry : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Destroy(gameObject);
        }
    }
}
