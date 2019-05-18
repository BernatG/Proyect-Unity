using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caida_jefe : MonoBehaviour {

    private GameObject jefe;

	// Use this for initialization
	void Start () {
        jefe = GameObject.Find("jefe1");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            GameObject.Find("psMuerte").GetComponent<Transform>().position = collision.gameObject.GetComponent<Transform>().position;
            GameObject.Find("psMuerte").GetComponent<ParticleSystem>().Play();
            collision.gameObject.GetComponent<Transform>().position = new Vector3(116f, 3.49f, 0f);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            jefe.GetComponent<jefeFinal1>().life = jefe.GetComponent<jefeFinal1>().maxLife;
            jefe.GetComponent<jefeFinal1>().activado = true;
            jefe.GetComponentInParent<Transform>().position = new Vector3(153f, -22.1f, 0);
            jefe.GetComponent<jefeFinal1>().turnosParaSalto = -1;
            jefe.GetComponent<jefeFinal1>().buscando = true;
            jefe.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            jefe.GetComponent<jefeFinal1>().velocidad = jefe.GetComponent<jefeFinal1>().velocidadInicial;

        }
    }
}
