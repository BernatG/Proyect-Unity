﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llave : MonoBehaviour {

    private puerta puerta;

    // Use this for initialization
    void Start (){
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {

            Destroy(this.gameObject);
        }   
    }
    
}
