using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadBeginGameOutro : MonoBehaviour
{

    public void newVideo()
    {
        StartCoroutine(newScene());
    }

private IEnumerator newScene()
{
    yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("BeginGameOutro");

    }
}
