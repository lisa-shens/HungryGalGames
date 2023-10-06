using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Name of the next scene to load
    public string nextSceneName;

    // Time to wait before transitioning to the next scene (in seconds)
    public float countdownDuration = 10f;

    private float countdownTimer;

    private void Start()
    {
        countdownTimer = countdownDuration;
    }

    private void Update()
    {
        countdownTimer -= Time.deltaTime;

        if (countdownTimer <= 0f)
        {
            // Load the next scene
          
            SceneManager.LoadScene("VictorScene");
        }
    }
}
