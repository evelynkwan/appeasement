using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsLive : MonoBehaviour
{
    public bool isMusic;
    public bool isAudio;
    public SettingsManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("SettingManager").GetComponent<SettingsManager>();
        isMusic = manager.isMusic;
        isAudio = manager.isAudio;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MusicOn()
    {
       isMusic = true;
    }

    public void MusicOff()
    {
        isMusic = false;
    }
    public void AudioOn()
    {
        isAudio = true;
    }

    public void AudioOff()
    {
        isAudio = false;
    }
}
