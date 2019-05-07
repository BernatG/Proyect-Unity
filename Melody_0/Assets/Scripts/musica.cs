using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class musica : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip clip;
    private VolumeValueChange volMenu;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        audioSource.volume = volMenu.audioSrc.volume;

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            audioSource.Stop();
        }
	}
}
