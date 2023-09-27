using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadVideo5 : MonoBehaviour
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
        SceneManager.LoadScene("Berry Jump");
    }
}
