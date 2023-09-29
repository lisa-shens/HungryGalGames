using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReapingName : MonoBehaviour
{
    public TMP_Text scoreText;
    public static int score = 0;

    public void PlaceAName()
    {
        score++;
        scoreText.text = "Entries: " + score;
    }

    public int getScore()
    {
        return score;
    }
}