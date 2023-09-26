using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 1f;
    public float lifeTime = 5;
    private float amplitude = 3f;
    private Vector3 originalScale;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        MoveToDirection(Vector2.right);
    }

    private void Update()
    {
        if (transform.position.x > amplitude)
        {
            MoveToDirection(Vector2.left);
        }
        else if (transform.position.x < -amplitude)
        {
            MoveToDirection(Vector2.right);
        }

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void MoveToDirection(Vector2 direction)
    {
        rb.velocity = direction * speed;

        transform.localScale = new Vector3(direction.x < 0 ? -originalScale.x : originalScale.x, originalScale.y,
            originalScale.z);
    }

    public void onHit()
    {
        Destroy(gameObject);
        //AddPoints();
    }

    //public void AddPoints()
    //{
    //    points += 1;

    //    Points pointsDisplay = FindObjectOfType<Points>();
    //    if (pointsDisplay != null)
    //    {
    //        pointsDisplay.UpdatePointsText();
    //    }
    //}

    //public static float GetPoints()
    //{
    //    return points;
    //}
}
