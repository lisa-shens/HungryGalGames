using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene2 : MonoBehaviour
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
        txt1.text = "you have been selected to represent your district";
        StartCoroutine(FadeInText(txt1));
        yield return new WaitForSeconds(4f);
        txt2.gameObject.SetActive(true);
        txt2.text = "you will now make your way to the capitol and meet all of Panem";
        StartCoroutine(FadeInText(txt2));
        yield return new WaitForSeconds(4f);
        txt3.gameObject.SetActive(true);
        txt3.text = "good luck in your interview!";
        StartCoroutine(FadeInText(txt3));
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Interview");
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
