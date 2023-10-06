using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    private float moveX;
    private bool isJumping = false;
    private bool isJumpAnimationPlaying = false;
    public Sprite[] frames;
    public float framesPerSecond = 10.0f;
    private float fallTimer = 0f;
 
    SpriteRenderer spriteRenderer;
    public Sprite spriteSide;
    private Color originalColor; // Store the player's original color

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // Store the original color
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal") * speed;

        // Check for jump input only if not already in a jump animation
        if (isJumping == true && !isJumpAnimationPlaying)
        {
            StartCoroutine(JumpAnimation());
        }

        // Check for left arrow input and not in a jump animation
        else if (Input.GetKey(KeyCode.LeftArrow) && !isJumpAnimationPlaying)
        {
            // Player is moving left
            spriteRenderer.sprite = spriteSide;
            spriteRenderer.flipX = true;
        }

        // Check for right arrow input and not in a jump animation
        else if (Input.GetKey(KeyCode.RightArrow) && !isJumpAnimationPlaying)
        {
            // Player is moving right
            spriteRenderer.sprite = spriteSide;
            spriteRenderer.flipX = false;
        }

        // Check if the player is continuously falling
        if (rb.velocity.y < 0f && !isJumping)
        {
            fallTimer += Time.deltaTime;

            if (fallTimer >= 2f) // Player falls for 2 seconds continuously
            {
                FindObjectOfType<SceneTransition>().StartFalling();
            }
        }
        else
        {
            fallTimer = 0f; // Reset the timer if the player jumps or lands on a platform
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
        if (collision.gameObject.CompareTag("Platform"))
        {
            FindObjectOfType<SceneTransition>().ResetFalling(); // Reset the fall timer
        }
        else
        {
            // Player has fallen off the platform, trigger the fall timer
            StartCoroutine(StartFallTimer());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Animal animal = collision.gameObject.GetComponent<Animal>();
        if (animal != null)
        {
            // Play the hurt animation (flash red)
            StartCoroutine(HurtAnimation());
        }
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

    IEnumerator StartFallTimer()
    {
        // Wait for 2 seconds before starting the fall timer
        yield return new WaitForSeconds(2f);

        // Start the fall timer
        FindObjectOfType<SceneTransition>().StartFalling();
    }

    IEnumerator HurtAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = originalColor;
    }
}