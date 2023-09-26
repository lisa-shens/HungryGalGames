using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    private float moveX;
    private bool isJumping = false; // Flag to track if the player is jumping
    private bool isJumpAnimationPlaying = false; // Flag to track if the jump animation is playing
    [Tooltip("The individual sprites of the animation")]
    public Sprite[] frames;
    [Tooltip("How fast does the animation play")]
    public float framesPerSecond = 10.0f; // Increased frames per second for smoother animation

    SpriteRenderer spriteRenderer;
    public Sprite spriteSide;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal") * speed;

        // Check for jump input only if not already in a jump animation
        if (isJumping == true && !isJumpAnimationPlaying)
        {
            StartCoroutine(JumpAnimation());
        }

        else if (Input.GetKey(KeyCode.LeftArrow) && !isJumpAnimationPlaying)
        {
            // Player is moving left
            spriteRenderer.sprite = spriteSide;
            spriteRenderer.flipX = true;
        }

        else if (Input.GetKey(KeyCode.RightArrow) && !isJumpAnimationPlaying)
        {
            // Player is moving right
            spriteRenderer.sprite = spriteSide;
            spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = rb.velocity;
        movement.x = moveX;
        rb.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = true;
    }

    IEnumerator JumpAnimation()
    {
        isJumpAnimationPlaying = true; // Set the flag to indicate that the jump animation is playing

        // The time each frame should be displayed
        float frameDuration = 1.0f / framesPerSecond;

        for (int i = 0; i < frames.Length; i++)
        {
            spriteRenderer.sprite = frames[i];
            yield return new WaitForSeconds(frameDuration);
        }

        // After the animation is complete, set the sprite back to the default one
        spriteRenderer.sprite = frames[0];

        isJumpAnimationPlaying = false; // Reset the flag to allow a new jump animation
        isJumping = false; // Set isJumping to false to indicate the jump animation is complete
    }
}
