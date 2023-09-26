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
        MoveToDirection(Vector2.right);
    }

    private void MoveToDirection(Vector2 direction)
    {
        direction.x = Mathf.Max(direction.x, 0);

        float randomizedSpeed = Random.Range(1f, 10f);

        rb.velocity = direction.normalized * randomizedSpeed;

        // Optionally, you can flip the object's scale based on the direction.
        transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
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
