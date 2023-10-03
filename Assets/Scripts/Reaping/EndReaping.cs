using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndReaping : MonoBehaviour
{
    public float countdownTime = 30.0f; // The countdown time in seconds
    public TMP_Text countdownText; // Reference to a Text component to display the countdown
    private float currentTime;
    public GameObject button1;
    public GameObject button2;

    void Start()
    {
        currentTime = countdownTime;
        countdownText.gameObject.SetActive(false);
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            countdownText.gameObject.SetActive(true);
            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);
            countdownText.text = ReapingName.score + " entries? Risky move... Best of luck to you.";
            StartCoroutine(ChangeBackgroundWithDelay());
        }
    }

    private IEnumerator ChangeBackgroundWithDelay()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        SceneManager.LoadScene("Scene2");
    }
}


