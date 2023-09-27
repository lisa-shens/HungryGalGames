using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReapingName : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;

    public void PlaceAName()
    {
        score++;
        scoreText.text = "Entries: " + score;
    }
}