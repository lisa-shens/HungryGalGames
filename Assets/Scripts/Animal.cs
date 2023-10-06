using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float minSpeed = 4f;
    public float maxSpeed = 10f;
    public float lifeTime = 5f;
    float randomizedSpeed;
    public float framesPerSecond = 5.0f;
    private PointsManager pointsManager;

    public Sprite[] frames;

    private int currentFrameIndex = 0;
    private float frameTimer;
    public AudioClip deerKillSound;
    public GameObject bloodPrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        frameTimer = 1.0f / framesPerSecond;

        randomizedSpeed = Random.Range(minSpeed, maxSpeed);
        pointsManager = GameObject.Find("PointsManager").GetComponent<PointsManager>();
    }

    private void Update()
    {
        rb.velocity = transform.right * randomizedSpeed;
        ChangeFrame();
    }

    private void ChangeFrame()
    {
        frameTimer -= Time.deltaTime;
        lifeTime -= Time.deltaTime;

        if (frameTimer <= 0)
        {
            currentFrameIndex++;

            if (currentFrameIndex >= frames.Length)
            {
                currentFrameIndex = 0; // Reset back to the first frame
            }

            frameTimer = 1.0f / framesPerSecond;
            spriteRenderer.sprite = frames[currentFrameIndex];
        }

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void onHit()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deerKillSound, transform.position);
        Instantiate(bloodPrefab, transform.position, transform.rotation);
        pointsManager.updatePoints(1f);
    }
}
