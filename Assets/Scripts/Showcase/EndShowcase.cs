using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndShowcase : MonoBehaviour
{
    public float countdownTime = 30.0f; // The countdown time in seconds
    private float currentTime;

    void Start()
    {
        currentTime = countdownTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            StartCoroutine(ChangeBackgroundWithDelay());
        }
    }

    private IEnumerator ChangeBackgroundWithDelay()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        SceneManager.LoadScene("Scene4");
    }
}


