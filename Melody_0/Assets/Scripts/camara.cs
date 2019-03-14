using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour {

    private Transform situacion;
    private GameObject jugador;
    private float jugadorPosX;
    private float jugadorPosY;

	// Use this for initialization
	void Start () {
        jugador = GameObject.FindGameObjectWithTag("player");

        //jugadorPosX = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>().position.x;
        //jugadorPosY = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>().position.y;
    }
	
	// Update is called once per frame
	void Update () {
        jugadorPosX = jugador.transform.position.x;
        jugadorPosY = jugador.transform.position.y;
        gameObject.transform.position = new Vector3(jugadorPosX, jugadorPosY + 2.5f, gameObject.transform.position.z);
    }
}
