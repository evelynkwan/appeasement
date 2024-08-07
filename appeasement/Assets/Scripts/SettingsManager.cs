using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    //References//
    public static SettingsManager instance;
    public SettingsLive live;
    public AudioMixer audioMixer;
    public bool isMusic;
    public bool isAudio;
    // Start is called before the first frame update
    void Start()
    {
       // live = GameObject.Find("SettingsLive").GetComponent<SettingsLive>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (SceneManager.GetSceneByName("Settings") == SceneManager.GetActiveScene())
        {
            live = GameObject.Find("SettingsLive").GetComponent<SettingsLive>();
            isMusic = live.isMusic;
            isAudio = live.isAudio;
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

    //Referenced on the ON button for music. 
    //Set the volume of the Music to 100 (ON)
    /*public void ToggleMusicOn()
    {
        audioMixer.SetFloat("Music", 100f);
    }

    public void ToggleMusicOff()
    {
        audioMixer.SetFloat("Music", 0f);
    }
    public void ToggleAudioOn()
    {
        audioMixer.SetFloat("Master", 100f);
    }

    public void ToggleAudioOff()
    {
        audioMixer.SetFloat("Master", 0f);
    }*/
}
