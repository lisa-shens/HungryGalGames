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

    // Start is called before the first frame update
    public void updatePoints(float inc)
    {
        score += inc;
        points.text = "Points: " + score;
    }
}