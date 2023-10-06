using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReapingName : MonoBehaviour
{
    private PointsManager pointsManager;
    public float breadCount = 0;

    private void Start()
    {
        pointsManager = GameObject.Find("PointsManager").GetComponent<PointsManager>();
    }

    public void PlaceAName()
    {
        breadCount += 1;
        pointsManager.updatePoints(2f);
    }

    public float getBreads()
    {
        return breadCount;
    }
}