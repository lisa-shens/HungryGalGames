using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipVideo : MonoBehaviour
{

    public void videoSkipped()
    {
        SceneManager.LoadScene("ReapingScene");
    }
}
