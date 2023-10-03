using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
        if (currentQuestion >= 0 && currentQuestion < QnA.Count)
        {
            QnA.RemoveAt(currentQuestion);
            if (QnA.Count == 0)
            {
                SceneManager.LoadScene("Scene4"); // Transition to the next scene when all questions are answered.
            }
            else
            {
                generateQuestion();
            }
        }
        else
        {
            Debug.LogWarning("Invalid currentQuestion index.");
        }
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<InterviewAnswers>().cheer = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];
            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<InterviewAnswers>().cheer = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            Debug.Log("Generated currentQuestion: " + currentQuestion);
            QuestionText.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.LogWarning("No more questions available.");
        }
    }
}