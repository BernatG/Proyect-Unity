using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValueChange : MonoBehaviour
{

    public AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSrc.volume = GlobalControl.Instance.musicVolume;
    }

    

    public void SetVolume(float vol)
    {
        GlobalControl.Instance.musicVolume = vol;
    }
}