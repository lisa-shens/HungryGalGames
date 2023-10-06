using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterviewAnswers : MonoBehaviour
{
    public bool cheer = false;
    public Interview interviewManager;
    public AudioSource audioSource;
    public AudioClip cheerSound;
    public AudioClip booSound;
    private PointsManager pointsManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pointsManager = GameObject.Find("PointsManager").GetComponent<PointsManager>();
        pointsManager.updatePoints(0f);
    }

    public void Answer()
    {
        if (cheer)
        {
            // play cheer audio
            audioSource.PlayOneShot(cheerSound);
            interviewManager.moveOn();
            pointsManager.updatePoints(3f);
        }
        else
        {
            // play boo audio
            audioSource.PlayOneShot(booSound);
            interviewManager.moveOn();
            pointsManager.updatePoints(-3f);
        }

    }
}