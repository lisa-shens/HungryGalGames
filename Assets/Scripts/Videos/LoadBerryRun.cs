using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class LoadBerryRun : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public Image spriteImage;
    public float fadeDuration = 2.0f; // Duration of the fade-in effect in seconds
    public TMP_Text countdown;

    private Color startColor;
    private Color targetColor = Color.white;
    private float elapsedTime = 0;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;
        spriteImage.gameObject.SetActive(false);
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Load a new scene when the video ends
        spriteImage.gameObject.SetActive(true);
        startColor = spriteImage.color;
        startColor.a = 0;
        spriteImage.color = startColor;
        countdown.gameObject.SetActive(false);

        // Start the fade-in effect
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        while (elapsedTime < fadeDuration)
        {
            // Calculate the new alpha value using Lerp
            float alpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);

            // Update the color with the new alpha
            spriteImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the alpha is exactly 1 at the end
        spriteImage.color = targetColor;
        UpdateCountdownText();
    }

    public void UpdateCountdownText()
    {
        countdown.gameObject.SetActive(true);
        countdown.text = "3";
        StartCoroutine(beginGame());
    }

    private IEnumerator beginGame()
    {
        yield return new WaitForSeconds(1f); // Wait for 5 seconds
        countdown.text = "2";
        yield return new WaitForSeconds(1f); // Wait for 5 seconds
        countdown.text = "1";
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Berry Jump");
    }
}
