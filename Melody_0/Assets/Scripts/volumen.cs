using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumen : MonoBehaviour {

    public AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource.volume = GlobalControl.Instance.musicVolume;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
