using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jefeFinal1 : MonoBehaviour {

    public float tiempoLimite = 1;
    public float velocidad;
    public int turnosNecesariosParaSalto = 0;

    private int turnosParaSalto;
    private Transform transformJugador;
    private Rigidbody2D rb;
    private float posicionJugadorX;
    private bool buscando;
    private bool direccion;
    private float tiempo = 0;

	// Use this for initialization
	void Start () {
        turnosParaSalto = 0;
        transformJugador = GameObject.FindGameObjectWithTag("player").transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
        buscando = true;
	}

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
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
        }
        else if (direccion == false && posicionJugadorX < gameObject.transform.position.x)
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
        }
        else {
            rb.velocity = new Vector2(0, rb.velocity.y);

            tiempo += Time.deltaTime;

            if (tiempo >= tiempoLimite) {
                buscando = true;
                tiempo = 0;
                turnosParaSalto++;
            }
        }
    }
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && turnosParaSalto >= turnosNecesariosParaSalto)
        {
            rb.velocity = new Vector2 (rb.velocity.x, 10);
            turnosParaSalto = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Destroy(collision.gameObject);
        }
    }
}
