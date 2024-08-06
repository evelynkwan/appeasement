using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneClickHandler : MonoBehaviour
{
    // Name of the next scene to load
    public string nextSceneName;

    void Update()
    {
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Load the next scene
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogError("Next scene name is not set.");
            }
        }
    }
}