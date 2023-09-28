using UnityEngine;
using TMPro;

public class Berry : MonoBehaviour
{
    private TMP_Text scoreText;
    private int score;
    public GameObject berry;

    private void Start()
    {
        scoreText = GameObject.Find("Points").GetComponent<TMP_Text>();
        score = 0;
    }

    private void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            collectBerry();
            print(score);
        }
    }

    public void collectBerry()
    {
        Destroy(gameObject);
        score++;
        scoreText.text = "Berries: " + score;
    }
}
