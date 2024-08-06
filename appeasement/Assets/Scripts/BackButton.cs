using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    // Reference to the button
    public Button backButton;

    // Name of the cutscene scene
    public string cutsceneBack;

    void Start()
    {
        // Add a listener to the button to call the PlayCutscene method when clicked
        if (backButton != null)
        {
            backButton.onClick.AddListener(PlayBackscene);
        }
    }

    void PlayBackscene()
    {
        // Load the cutscene scene
        if (!string.IsNullOrEmpty(cutsceneBack))
        {
            SceneManager.LoadScene(cutsceneBack);
        }
        else
        {
            Debug.LogError("Cutscene scene name is not set.");
        }
    }
}