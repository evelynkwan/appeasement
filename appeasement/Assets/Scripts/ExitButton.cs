using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button exitButton;
    void Start()
    {
       if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
        }
    }

    // Update is called once per frame
    void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
