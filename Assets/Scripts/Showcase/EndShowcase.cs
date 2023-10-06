using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndShowcase : MonoBehaviour
{
    public TMP_Text endText;
    public Sprite backgroundB;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        endText.gameObject.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public void end()
    {
        print("end");
        endText.gameObject.SetActive(true);
        endText.text = "You have successfully calibrated your weapon.";
        StartCoroutine(ChangeBackgroundWithDelay());
        spriteRenderer.enabled = true; // Turn on the sprite
        spriteRenderer.sprite = backgroundB;
    }

    private IEnumerator ChangeBackgroundWithDelay()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        SceneManager.LoadScene("Scene4");
    }
}


