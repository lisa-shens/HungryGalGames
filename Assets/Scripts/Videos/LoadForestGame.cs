using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadForestGame : MonoBehaviour
{

    private void Start()
    {
        GameObject.FindGameObjectWithTag("IntroMusic").GetComponent<MusicIntro>().StopMusic();
    }


    public void LoadScene ()
    {
        // Load a new scene when the video ends
        SceneManager.LoadScene("ForestGame");
    }
}
