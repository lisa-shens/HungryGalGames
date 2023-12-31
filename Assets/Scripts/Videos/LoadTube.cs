using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadTube : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<ShowcaseMusic>().StopMusic();
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;
    }


    void OnVideoEnd(VideoPlayer vp)
    {
        // Load a new scene when the video ends
        SceneManager.LoadScene("TubeVideo");
    }
}
