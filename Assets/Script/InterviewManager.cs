using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interview : MonoBehaviour
{

    public List<InterviewQuestions> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI QuestionText;

    private void Start()
    {
        generateQuestion();
    }

    public void moveOn()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<InterviewAnswers>().cheer = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];
            if(QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<InterviewAnswers>().cheer = true;
            }
        }
    }

    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionText.text = QnA[currentQuestion].Question;

        SetAnswers();
    }
}
