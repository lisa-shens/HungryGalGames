using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public float countdownTime = 30.0f; // The countdown time in seconds
    public TMP_Text countdownText; // Reference to a Text component to display the countdown
    private float currentTime;
    public Sprite backgroundB; // Reference to your second background sprite
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentTime = countdownTime;
        countdownText.gameObject.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            countdownText.gameObject.SetActive(true);
            spriteRenderer.enabled = true; // Turn on the sprite
            spriteRenderer.sprite = backgroundB;

            StartCoroutine(ChangeBackgroundWithDelay());
        }
    }

    private IEnumerator ChangeBackgroundWithDelay()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        SceneManager.LoadScene("Scene2");
    }
}


