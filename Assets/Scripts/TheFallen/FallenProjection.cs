using System.Collections;
using UnityEngine;

public class FallenProjection : MonoBehaviour
{
    private Vector3 initialPosition;
    public float shakeAmount = 0.05f;
    public float shakeDuration = 15.0f;
    private bool isShaking = false;
    public SpriteRenderer spriteToShake;
    public float shakeDecreaseFactor = 1.0f;
    public float fadeInDuration = 2.0f;

    private void Start()
    {
        // Store the initial position of the GameObject.
        spriteToShake = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
        StartShake(spriteToShake, shakeAmount, shakeDuration);
        StartCoroutine(FadeInAndShake(spriteToShake));
    }

    private void Update()
    {

        if (isShaking)
        {
            if (shakeDuration > 0)
            {
                // Generate a random offset for the position.
                Vector3 randomOffset = Random.insideUnitSphere * shakeAmount;

                // Apply the offset to the GameObject's position.
                transform.position = initialPosition + randomOffset;

                // Reduce shakeDuration over time.
                shakeDuration -= Time.deltaTime;

                shakeAmount *= shakeDecreaseFactor;
            }
            else
            {
                // Reset the position when the shake is done.
                transform.position = initialPosition;
                isShaking = false;
            }
        }
    }

    private IEnumerator FadeInAndShake(SpriteRenderer spriteFadingIn)
    {
        spriteFadingIn.color = new Color(1f, 1f, 1f, 0f); // Start with a transparent sprite

        float fadeInDuration = 5.0f; // Duration of the fade-in effect

        for (float t = 0; t < fadeInDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, t / fadeInDuration);
            spriteToShake.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
        StartCoroutine(StartFadeOutAfterDelay(spriteFadingIn, 5.0f));
    }

    private IEnumerator StartFadeOutAfterDelay(SpriteRenderer spriteFadingIn, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Start the fade-out effect.
        StartCoroutine(FadeOut(spriteFadingIn));
    }

    private IEnumerator FadeOut(SpriteRenderer spriteFadingIn)
    {
        float fadeOutDuration = 2.0f; // Duration of the fade-out effect

        for (float t = 0; t < fadeOutDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, t / fadeOutDuration);
            spriteFadingIn.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
    }

    public void StartShake(SpriteRenderer spriteRenderer, float amount, float duration)
    {
        if (!isShaking)
        {
            // Store the initial position of the GameObject.
            initialPosition = spriteRenderer.transform.position;

            shakeAmount = amount;
            shakeDuration = duration;
            isShaking = true;
        }
    }
}