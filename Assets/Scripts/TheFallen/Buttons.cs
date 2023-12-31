using UnityEngine;

public class Buttons : MonoBehaviour
{
    private PointsManager pointsManager;

    private void Start()
    {
        pointsManager = GameObject.Find("PointsManager").GetComponent<PointsManager>();

    }
    // Example function to quit the game
    public void QuitGame()
    {
        // Check if the application is running in the Unity Editor (for testing purposes)
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            // Quit the application in a build (standalone, mobile, etc.)
            Application.Quit();
        }
    }

    public void StartOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("BeginGame");
        pointsManager.resetAllPoints();
    }
}