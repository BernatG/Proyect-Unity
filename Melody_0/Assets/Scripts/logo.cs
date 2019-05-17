using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logo : MonoBehaviour {

    int contador;

	// Use this for initialization
	void Start () {
        contador = 0;
	}
	
	// Update is called once per frame
	void Update () {
        contador += 1;
        if (contador == 232)
        {
            Application.LoadLevel("Menu");
        }
	}
}
