using UnityEngine;

public class ShowcaseMusic: MonoBehaviour
{
    private AudioSource _audioSource;
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<InterviewMusic>().StopMusic();
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
