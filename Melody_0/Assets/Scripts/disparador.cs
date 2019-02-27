﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparador : MonoBehaviour {

    public float timeLimit;
    private float time;
    public GameObject projectile;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= timeLimit) {
            Instantiate(projectile, gameObject.transform.position, gameObject.transform.localRotation);
            time = 0;
        }
    }
}
