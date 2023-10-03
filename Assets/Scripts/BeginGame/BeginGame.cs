using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginGame : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_Text welcomeText;
    public Button button;
    public TMP_Text countdown;

    private void Start()
    {
        button.onClick.AddListener(UpdateCountdownText);
        welcomeText.gameObject.SetActive(false);
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
        string playerName = nameInputField.text;
        welcomeText.text = "Welcome, " + playerName + "... are you ready?";
        StartCoroutine(openButton(playerName));
    }

    private IEnumerator openButton(string playerName)
    {
        yield return new WaitForSeconds(3f); // Wait for 5 seconds
        welcomeText.text = "... may the odds be ever in your favor...";
        yield return new WaitForSeconds(3f); // Wait for 5 seconds
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
}
