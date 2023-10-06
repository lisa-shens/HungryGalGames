using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGameButton : MonoBehaviour
{

    public TMP_Text countdown;

    // Start is called before the first frame update
    void Start()
    {
        countdown.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void onClick()
    {
        StartCoroutine(openButton());
    }

    private IEnumerator openButton()
    {
        countdown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f); // Wait for 5 seconds
        countdown.text = "3";
        yield return new WaitForSeconds(1f); // Wait for 5 seconds
        countdown.text = "2";
        yield return new WaitForSeconds(1f); // Wait for 5 seconds
        countdown.text = "1";
    }
}
