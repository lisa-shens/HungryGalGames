using UnityEngine;

public class CountdownMusic: MonoBehaviour
{
    private AudioSource _audioSource;
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("ShowcaseMusic").GetComponent<ShowcaseMusic>().StopMusic();
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
