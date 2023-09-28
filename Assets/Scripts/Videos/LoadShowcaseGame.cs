using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadVideo4 : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    
    void OnVideoEnd(VideoPlayer vp)
    {
        // Load a new scene when the video ends
        SceneManager.LoadScene("ShowcaseScene");
    }
}
