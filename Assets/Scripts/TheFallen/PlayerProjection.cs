using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProjection : MonoBehaviour
{

    private Vector3 initialPosition;
    public float shakeAmount = 0.05f;
    public float shakeDuration = 15.0f;
    public SpriteRenderer spriteToShake;
    public float shakeDecreaseFactor = 1.0f;
    public float fadeInDuration = 2.0f;
    private bool begin = false;
    public TMP_Text txt1;
    private string playerName;
    public Button button1ToAppear;
    public Button button2ToAppear;
    private float timer = 0f;
    private bool buttonVisible = false;

    private void Start()
    {
        StartCoroutine(DelayStart());
        spriteToShake = GetComponent<SpriteRenderer>();
        spriteToShake.enabled = false;
        txt1.gameObject.SetActive(false);
        playerName = BeginGame.getName();
        button1ToAppear.gameObject.SetActive(false);
        button2ToAppear.gameObject.SetActive(false);
    }

    private IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(12f);
        begin = true;
    }

    private void Update()
    {
        if (begin)
        {
            spriteToShake.enabled = true;
            initialPosition = transform.position;
            StartCoroutine(FadeIn(spriteToShake));
        }
        timer += Time.deltaTime;

        // Check if the timer has reached 35 seconds
        if (timer >= 35f && !buttonVisible)
        {
            // Show the button
            button1ToAppear.gameObject.SetActive(true);
            button2ToAppear.gameObject.SetActive(true);
            button1ToAppear.onClick.AddListener(StartOver);
            button2ToAppear.onClick.AddListener(QuitGame);
            buttonVisible = true;
        }
    }

    private IEnumerator FadeIn(SpriteRenderer spriteFadingIn)
    {
        spriteFadingIn.color = new Color(1f, 1f, 1f, 0f); // Start with a transparent sprite

        float fadeInDuration = 5.0f; // Duration of the fade-in effect

        for (float t = 0; t < fadeInDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, t / fadeInDuration);
            spriteToShake.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
        txt1.gameObject.SetActive(true);
        txt1.text = playerName + "\nDistrict 12";
        StartCoroutine(FadeInText(txt1));
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

    IEnumerator FadeInText(TMP_Text words)
    {
        // Time it takes for the text to fully fade in (in seconds).
        float fadeDuration = 1.0f;

        // Initial and target alpha values.
        float startAlpha = 0f;
        float targetAlpha = 1f;

        Color textColor = words.color;
        float currentTime = 0;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, currentTime / fadeDuration);
            textColor.a = alpha;
            words.color = textColor;
            yield return null;
        }

        // Ensure that the text is fully opaque when the fade-in is complete.
        textColor.a = 1f;
        words.color = textColor;
    }

    public void QuitGame()
    {
        // Check if the application is running in the Unity Editor (for testing purposes)
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            // Quit the application in a build (standalone, mobile, etc.)
            Application.Quit();
        }
    }

    public void StartOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("BeginGame");
    }
}