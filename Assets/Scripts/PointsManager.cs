using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;

    //void Start()
    //{
    //    // Initialize points text
    //    UpdatePointsText();
    //}

    //// Add points to the total and update the points text display
    //public void AddPoints(int pointsToAdd)
    //{
    //    points += pointsToAdd;
    //    UpdatePointsText();
    //}

    //// Update the points text display
    //private void UpdatePointsText()
    //{
    //    pointsText.text = "Points: " + points.ToString();
    //}

   public void collectBerry()
   {
        score++;
        scoreText.text = "Berries: " + score;
   }
}
