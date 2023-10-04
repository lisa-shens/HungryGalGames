using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginGame : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_Text welcomeText;
    public TMP_Text oddsText;
    public Button button;
    public TMP_Text countdown;
    public static string playerName;

    public static string getName()
    {
        return playerName;
    }

    private void Start()
    {
        button.onClick.AddListener(UpdateCountdownText);
        welcomeText.gameObject.SetActive(false);
        oddsText.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        countdown.gameObject.SetActive(false);
    }

    private void Update()
    {
        string userInput = Input.inputString;
        nameInputField.text += userInput;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            UpdateWelcomeText();
        }
    }

    public void UpdateWelcomeText()
    {
        welcomeText.gameObject.SetActive(true);
        playerName = nameInputField.text;
        welcomeText.text = "Welcome, " + playerName + "... are you ready?";
        StartCoroutine(FadeInText(welcomeText));
        StartCoroutine(openButton(playerName));
    }

    private IEnumerator openButton(string playerName)
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        StartCoroutine(FadeOutText(welcomeText));
        oddsText.gameObject.SetActive(true);
        oddsText.text = "... may the odds be ever in your favor...";
        StartCoroutine(FadeInText(oddsText));
        yield return new WaitForSeconds(7f); // Wait for 5 seconds
        button.gameObject.SetActive(true);
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
        SceneManager.LoadScene("IntroForestGame");
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

    IEnumerator FadeOutText(TMP_Text words)
    {
        // Time it takes for the text to fully fade out (in seconds).
        float fadeDuration = 1.0f;

        // Initial and target alpha values.
        float startAlpha = 1f;
        float targetAlpha = 0f;

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

        // Ensure that the text is fully transparent when the fade-out is complete.
        textColor.a = 0f;
        words.color = textColor;
    }
}
