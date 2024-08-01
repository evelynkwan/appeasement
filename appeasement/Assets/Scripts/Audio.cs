using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip popper;
    public AudioClip gun;
    public AudioClip hammer;
    public AudioClip bubble;
    public AudioClip cannon;
    public AudioClip ribbon;
    public AudioClip cheer;
    private AudioSource source;
    private BattleUI bui;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        bui = GameObject.Find("Canvas").GetComponent<BattleUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySEPlayer(bool isSpecial)
    {
        if (isSpecial)
        {
            source.clip = gun;
            source.Play();
            source.time = 0.265f;
        }
        else
        {
            source.clip = popper;
            source.Play();
            source.time = 0.35f;
        }
    }

    public void Defend()
    {
        source.clip = cheer;
        source.Play();
        source.time = 0.49f;
    }

    public void PlaySEEnemy(GameObject enemy)
    {
        if (enemy == bui.Dog)
        {
            source.clip = cannon;
            source.Play();
            source.time = 0.15f;
        }
        else if (enemy == bui.Something)
        {
            source.clip = hammer;
            source.Play();
            source.time = 0.275f;
        }
        else if (enemy == bui.Angy)
        {
            source.clip = bubble;
            source.Play();
            source.time = 0.35f;
        }
        else
        {
            source.clip = ribbon;
            source.Play();
            source.time = 1.085f;
        }
    }
}
