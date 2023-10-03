using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterviewAnswers : MonoBehaviour
{
    public bool cheer = false;
    public Interview interviewManager;

    public void Answer()
    {
        if (cheer)
        {
            // play cheer audio
            interviewManager.moveOn();
        }
        else
        {
            // play boo audio
            interviewManager.moveOn();
        }

    }
}
