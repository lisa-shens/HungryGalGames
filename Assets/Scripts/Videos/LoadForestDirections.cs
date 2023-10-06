using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadForestDirections : MonoBehaviour
{
    public AudioClip sound;

    public void onClick()
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        StartCoroutine(openButton());
    }

    private IEnumerator openButton()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("IntroForestGame");
    }
}
