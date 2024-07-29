using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public Button audioOn;
    public Button audioOff;
    // Start is called before the first frame update
    void Start()
    {
        audioOn.onClick.AddListener(TurnAudioOn);
        audioOff.onClick.AddListener(TurnAudioOff);
        UpdateButtonStates();
    }

    void TurnAudioOn()
    {
        audioSource.mute = false;
        UpdateButtonStates();
    }
    void TurnAudioOff()
    {
        audioSource.mute = true;
        UpdateButtonStates();
    }
    // Update is called once per frame
    void UpdateButtonStates()
    {
        audioOn.gameObject.SetActive(audioSource.mute);
        audioOff.gameObject.SetActive(!audioSource.mute);
    }
}
