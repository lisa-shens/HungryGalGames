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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Answer()
    {
        if (cheer)
        {
            // play cheer audio
            audioSource.PlayOneShot(cheerSound);
            interviewManager.moveOn();
        }
        else
        {
            // play boo audio
            audioSource.PlayOneShot(booSound);
            interviewManager.moveOn();
        }

    }
}