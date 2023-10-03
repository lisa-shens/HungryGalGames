using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene4 : MonoBehaviour
{
    public TMP_Text txt2;
    public TMP_Text txt3;
    public TMP_Text txt4;
    public TMP_Text txt5;
    public TMP_Text txt6;
    public TMP_Text txt7;

    void Start()
    {
        txt2.gameObject.SetActive(false);
        txt3.gameObject.SetActive(false);
        txt4.gameObject.SetActive(false);
        txt5.gameObject.SetActive(false);
        txt6.gameObject.SetActive(false);
        txt7.gameObject.SetActive(false);
        StartCoroutine(UpdateWelcomeTxt1());
    }

    private IEnumerator UpdateWelcomeTxt1()
    {
        txt2.gameObject.SetActive(true);
        txt2.text = "it is time.";
        StartCoroutine(FadeInText(txt2));
        yield return new WaitForSeconds(2f);
        txt3.gameObject.SetActive(true);
        txt3.text = "may the odds be";
        StartCoroutine(FadeInText(txt3));
        yield return new WaitForSeconds(1f);
        txt4.gameObject.SetActive(true);
        txt4.text = "ever";
        StartCoroutine(FadeInText(txt4));
        yield return new WaitForSeconds(1f);
        txt5.gameObject.SetActive(true);
        txt5.text = "in";
        StartCoroutine(FadeInText(txt5));
        yield return new WaitForSeconds(1f);
        txt6.gameObject.SetActive(true);
        txt6.text = "your";
        StartCoroutine(FadeInText(txt6));
        yield return new WaitForSeconds(1f);
        txt7.gameObject.SetActive(true);
        txt7.text = "favor";
        StartCoroutine(FadeInText(txt7));
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Berry Jump");
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
}
