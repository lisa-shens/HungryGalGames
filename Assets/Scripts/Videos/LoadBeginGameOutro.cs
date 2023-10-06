using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadBeginGameOutro : MonoBehaviour
{

    public void nextVideo()
    {
        // Load a new scene when the video ends
        SceneManager.LoadScene("BeginGameOutro");
    }
}
