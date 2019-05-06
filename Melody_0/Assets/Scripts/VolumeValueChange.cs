using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeValueChange : MonoBehaviour
{

    public  AudioMixerGroup musica;
    private float musicVolume = 1f;

  
    void Start()
    {
        musica = GetComponent<AudioMixerGroup>();
    }

    void Update()
    {

        musica = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}