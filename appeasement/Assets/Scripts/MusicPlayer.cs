using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip title;
    public AudioClip battle;
    public AudioClip boss;
    public AudioClip upgrade;
    public AudioClip win;
    private AudioSource source;
    public SettingsManager settings;
    // Start is called before the first frame update
    void Start()
    {
        settings = GameObject.Find("SettingManager").GetComponent<SettingsManager>();
        source = GetComponent<AudioSource>();
        Destroy(GameObject.Find("TitleScreenPlayer"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Victory()
    {
        if (source.clip == win && source.isPlaying)
        {

        }
        else if(settings.isMusic)
        {
            source.clip = win;
            source.time = 0;
            source.loop = false;
            source.Play();
        }
    }
    public void NormalBattle(bool isUpgrades, bool isBoss)
    {
        if (isBoss)
        {
            if (source.clip == boss && source.isPlaying)
            {

            }
            else if (settings.isMusic)
            {
                source.clip = boss;
                source.time = 0;
                source.loop = true;
                source.Play();
            }
        }
        else
        {
            if (isUpgrades)
            {
                if (source.clip == upgrade && source.isPlaying)
                {

                }
                else if (settings.isMusic)
                {
                    source.clip = upgrade;
                    source.time = 0;
                    source.loop = false;
                    source.Play();
                }
            }
            else
            {
                if (source.clip == battle && source.isPlaying)
                {

                }
                else if (settings.isMusic)
                {
                    source.clip = battle;
                    source.time = 0;
                    source.loop = true;
                    source.Play();
                }
            }
        }
    }
}
