using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    // Reference to the button
    public Button playButton;

    // Name of the cutscene scene
    public string cutsceneSceneName;

    void Start()
    {
        // Add a listener to the button to call the PlayCutscene method when clicked
        if (playButton != null)
        {
            playButton.onClick.AddListener(PlayCutscene);
        }
    }

    void PlayCutscene()
    {
        // Load the cutscene scene
        if (!string.IsNullOrEmpty(cutsceneSceneName))
        {
            SceneManager.LoadScene(cutsceneSceneName);
        }
        else
        {
            Debug.LogError("Cutscene scene name is not set.");
        }
    }
}