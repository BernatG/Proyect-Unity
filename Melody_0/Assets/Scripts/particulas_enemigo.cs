using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particulas_enemigo : MonoBehaviour {
    public float tiempoParaEmision;
    private float tiempo = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tiempo += Time.deltaTime;

        if (tiempo >= tiempoParaEmision)
        {
            GetComponent<ParticleSystem>().Stop();
        }
	}
}
