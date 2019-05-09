using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class musica : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip clip;
    public float musicVolume;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        DontDestroyOnLoad(this.gameObject);
        audioSource.volume = GlobalControl.Instance.musicVolume;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            audioSource.Stop();
        }
    }
}
