using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMusic : MonoBehaviour
{
    public SettingsManager settings;
    // Start is called before the first frame update
    void Start()
    {
        settings = GameObject.Find("SettingManager").GetComponent<SettingsManager>();
        if (settings.isMusic)
        {
            this.GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
