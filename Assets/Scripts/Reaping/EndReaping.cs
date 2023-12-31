using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndReaping : MonoBehaviour
{
    public float countdownTime = 10.0f;
    public TMP_Text countdownText;
    private float currentTime;
    public GameObject button1;
    public GameObject button2;
    private ReapingName reapingName;
    private PointsManager pointsManager;

    void Start()
    {
        currentTime = countdownTime;
        countdownText.gameObject.SetActive(false);
        reapingName = GameObject.Find("NameInPot").GetComponent<ReapingName>();
        pointsManager = GameObject.Find("PointsManager").GetComponent<PointsManager>();
        pointsManager.updatePoints(0f);
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
            countdownText.text = reapingName.getBreads() + " entries? Risky move... Best of luck to you.";
            StartCoroutine(ChangeBackgroundWithDelay());
        }
    }

    private IEnumerator ChangeBackgroundWithDelay()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        SceneManager.LoadScene("Scene2");
    }
}


