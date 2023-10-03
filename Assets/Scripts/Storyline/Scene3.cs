using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene3 : MonoBehaviour
{
    public TMP_Text txt1;
    public TMP_Text txt2;
    public TMP_Text txt3;

    void Start()
    {
        txt1.gameObject.SetActive(false);
        txt2.gameObject.SetActive(false);
        txt3.gameObject.SetActive(false);
        StartCoroutine(UpdateWelcomeTxt1());
    }

    private IEnumerator UpdateWelcomeTxt1()
    {
        txt1.gameObject.SetActive(true);
        txt1.text = "it is now time to showcase your skills to the people of the capitol";
        StartCoroutine(FadeInText(txt1));
        yield return new WaitForSeconds(4f);
        txt2.gameObject.SetActive(true);
        txt2.text = "you will be ranked among the other contestants, so be careful with your every move";
        StartCoroutine(FadeInText(txt2));
        yield return new WaitForSeconds(4f);
        txt3.gameObject.SetActive(true);
        txt3.text = "good luck!";
        StartCoroutine(FadeInText(txt3));
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("ShowcaseScene");
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