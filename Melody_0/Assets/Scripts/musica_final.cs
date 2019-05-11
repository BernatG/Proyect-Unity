using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musica_final : MonoBehaviour {

    private AudioSource musicaFinal;

	// Use this for initialization
	void Start () {
        musicaFinal = GetComponent<AudioSource>();
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "player")
        {
            musicaFinal.Play();
            Destroy(GameObject.Find("origen_musica"));
        }
        else
        {
            musicaFinal.Stop();
        }
    }
}
