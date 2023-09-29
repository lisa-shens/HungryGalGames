using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BeginGameButton : MonoBehaviour
{

    public TMP_Text countdown;

    // Start is called before the first frame update
    void Start()
    {
        countdown.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator openButton(string playerName)
    {
        yield return new WaitForSeconds(1f); // Wait for 5 seconds
        countdown.text = "3";
        yield return new WaitForSeconds(1f); // Wait for 5 seconds
        countdown.text = "3";
        yield return new WaitForSeconds(1f); // Wait for 5 seconds
        countdown.text = "1";
    }
}
