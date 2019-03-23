using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jefeFinal1 : MonoBehaviour {

    public float tiempoLimite = 1;

    private Transform transformJugador;
    private Rigidbody2D rb;
    private float posicionJugadorX;
    private bool buscando;
    private bool direccion;
    private float tiempo = 0;

	// Use this for initialization
	void Start () {
        transformJugador = GameObject.FindGameObjectWithTag("player").transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
        buscando = true;
	}

    /*IEnumerator espera()
    {
        yield return new WaitForSeconds(4);
    }*/

    // Update is called once per frame
    void Update () {

        if (buscando == true) {
            posicionJugadorX = transformJugador.position.x;
            buscando = false;
        
            if (posicionJugadorX > gameObject.transform.position.x) {
                direccion = true;
            }
            else if (posicionJugadorX < gameObject.transform.position.x)
            {
                direccion = false;
            }
        }

        if (direccion == true && posicionJugadorX > gameObject.transform.position.x)
        {
            rb.velocity = new Vector2(2, 0);
        }
        else if (direccion == false && posicionJugadorX < gameObject.transform.position.x)
        {
            rb.velocity = new Vector2(-2, 0);
        }
        else {
            rb.velocity = new Vector2(0, 0);

            tiempo += Time.deltaTime;

            if (tiempo >= tiempoLimite) {
                buscando = true;
                tiempo = 0;
            }
        }
        //StartCoroutine(espera());
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player") {
            Destroy(collision.gameObject);
        }
    }
}
