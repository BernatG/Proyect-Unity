using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particulas_enemigo : MonoBehaviour {
    public float tiempoParaEmision;
    private float tiempo = 0;

    public GameObject enemy;
	// Use this for initialization
	void Start () {
        GetComponent<ParticleSystem>().Pause();
	}
	
	// Update is called once per frame
	void Update () {
        if (enemy.activeInHierarchy == true)
        {
            transform.position = enemy.transform.position;
        }
        else
        {
            tiempo += Time.deltaTime;

            if (tiempo >= tiempoParaEmision)
            {
                GetComponent<ParticleSystem>().Stop();
            }
        }
	}
}
