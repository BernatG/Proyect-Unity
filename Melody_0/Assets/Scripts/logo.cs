using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logo : MonoBehaviour {

    int contador;
    public int segundos = 232;
    public string scena;

	// Use this for initialization
	void Start () {
        contador = 0;
	}
	
	// Update is called once per frame
	void Update () {
        contador += 1;
        if (contador == segundos)
        {
            print("hola");
            Application.LoadLevel(scena);
        }
	}
}
