using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenPlayer : MonoBehaviour
{
    public static TitleScreenPlayer instance;
    public SettingsManager settingsManager;
    // Start is called before the first frame update
    void Start()
    {
        settingsManager = GameObject.Find("SettingManager").GetComponent<SettingsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        settingsManager = GameObject.Find("SettingManager").GetComponent<SettingsManager>();
            if (!settingsManager.isMusic)
            {
                this.GetComponent<AudioSource>().Stop();
            }
            else if (!this.GetComponent<AudioSource>().isPlaying)
            {
                this.GetComponent<AudioSource>().Play();
            }
        
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
