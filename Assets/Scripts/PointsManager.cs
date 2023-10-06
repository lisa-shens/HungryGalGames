using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public TMP_Text points;
    private static float score;

    public float getScore()
    {
        return score;
    }

    public void updatePoints(float inc)
    {
        score += inc;
        points.text = "Points: " + score;
    }
}