using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public float fallDuration = 10f; // Duration for falling before transitioning to the new scene

    private bool isFalling = false;
    private float fallTimer = 0f;

    private void Update()
    {
        if (isFalling)
        {
            fallTimer += Time.deltaTime;

            // Check if the falling duration has been reached
            if (fallTimer >= fallDuration)
            {
                // Transition to the "FallenTributes" scene by its name (no need to specify the path)
                SceneManager.LoadScene("FallenTributes");
            }
        }
    }

    public void StartFalling()
    {
        isFalling = true;
    }

    public void ResetFalling()
    {
        isFalling = false;
        fallTimer = 0f; // Reset the timer
    }
}
