using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public TMP_Text pointsText;

    private void Start()
    {
        // Initialize points text
        //UpdatePointsText();
    }

    // Update the points text display
    public void UpdatePointsText()
    {
        //pointsText.text = "Points: " + Deer.GetPoints().ToString();
    }
}
