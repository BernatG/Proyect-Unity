using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    //public bool _in = false;

	// Use this for initialization
	void Start () {

        GetComponent<Animator>().SetTrigger("fade");
        GetComponent<Animator>().SetBool("fade_out", true);
    }
	
	// Update is called once per frame
	void Update () {

	}
}
