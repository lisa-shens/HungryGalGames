using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private float score = 0;

    private float getScore()
    {
        return score;
    }

    public void CollectBerry()
    {
        score += 3;
        scoreText.text = "Berries: " + getScore();
    }
}