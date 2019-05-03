using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class jefeFinal1 : MonoBehaviour {

    public float tiempoLimite = 1;
    public float velocidad;
    public int turnosNecesariosParaSalto = 0;
    private int turnosParaSalto;

    private Transform transformJugador;
    private Rigidbody2D rb;
    private float posicionJugadorX;

    private bool activado;
    private bool buscando;
    private bool direccion;

    private float tiempo = 0;
    private bool grounded = true;
    public int life = 1;
    private float fLife;
    private float maxLife;

    public Image imgLife;
    private SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
        turnosParaSalto = 0;
        transformJugador = GameObject.FindGameObjectWithTag("player").transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
        buscando = true;
        renderer = GetComponent<SpriteRenderer>();
        activado = false;
        maxLife = life;
	}

    // Update is called once per frame
    void FixedUpdate () {
        if (activado)
        {
            fLife = life;
            imgLife.fillAmount = fLife / maxLife;
            
            if (life <= 0)
            {
                SceneManager.LoadScene("Menu");
            }

            if (buscando == true)
            {
                posicionJugadorX = transformJugador.position.x;
                buscando = false;

                if (posicionJugadorX > gameObject.transform.position.x)
                {
                    direccion = true;
                }
                else if (posicionJugadorX < gameObject.transform.position.x)
                {
                    direccion = false;
                }
            }

            if (grounded)
            {
                if (direccion == true && posicionJugadorX > gameObject.transform.position.x /*+ (GetComponent<SpriteRenderer>().bounds.size.x / 2)*/)
                {
                    rb.velocity = new Vector2(velocidad, rb.velocity.y);
                    renderer.flipX = true;
                }
                else if (direccion == false && posicionJugadorX < gameObject.transform.position.x /*- (GetComponent<SpriteRenderer>().bounds.size.x / 2)*/)
                {
                    rb.velocity = new Vector2(-velocidad, rb.velocity.y);
                    renderer.flipX = false;
                }
                else
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);

                    tiempo += Time.deltaTime;

                    if (tiempo >= tiempoLimite)
                    {
                        buscando = true;
                        tiempo = 0;
                        turnosParaSalto++;
                    }
                }
            }
        }
        else if (transformJugador.position.y < -18)
        {
            if (transformJugador.position.x > 116)
            {
                activado = true;
            }
        }
        
    }
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && turnosParaSalto >= turnosNecesariosParaSalto)
        {
            rb.velocity = new Vector2 (rb.velocity.x, 10);
            turnosParaSalto = -1;
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "suelo")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "limite")
        {
            direccion = true;
            tiempo = 0;
            turnosParaSalto++;
        }
    }
}
