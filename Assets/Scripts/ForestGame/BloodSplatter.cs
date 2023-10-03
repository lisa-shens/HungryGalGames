using UnityEngine;
using System.Collections;

public class Sparkle : MonoBehaviour
{

    public Sprite[] frames;
    public float framesPerSecond = 5;

    SpriteRenderer spriteRenderer;
    private int currentFrameIndex;
    private float frameTimer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        frameTimer = (1f / framesPerSecond);
        currentFrameIndex = 0;
    }

    void Update()
    {
        frameTimer -= Time.deltaTime;

        if (frameTimer <= 0)
        {
            currentFrameIndex++;
            if (currentFrameIndex >= frames.Length)
            {
                Destroy(gameObject);
                return;
            }
            frameTimer = (1f / framesPerSecond);
            spriteRenderer.sprite = frames[currentFrameIndex];
        }
    }


}