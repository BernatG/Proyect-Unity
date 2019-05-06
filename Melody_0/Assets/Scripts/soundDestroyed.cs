using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundDestroyed : MonoBehaviour {

    public GameObject enemy;
    public AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (enemy.activeInHierarchy == false)
        {
            audio.Play();
        }
	}
}
