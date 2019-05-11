using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class jefeFinal1 : MonoBehaviour {

    public float tiempoLimite = 1;
    public float velocidad;
    public float velocidadInicial;
    public int turnosNecesariosParaSalto = 0;
    public AudioClip clip;
    private int turnosParaSalto;

    private Transform transformJugador;
    private Rigidbody2D rb;
    private float posicionJugadorX;

    private bool activado;
    private bool buscando;
    private bool direccion;
    private bool musica = false;

    private float tiempo = 0;
    private bool grounded = true;
    public float life = 1;
    private float maxLife;

    public GameObject imgLife;
    private new SpriteRenderer renderer;
    // Use this for initialization
    void Start () {
        turnosParaSalto = 0;
        transformJugador = GameObject.FindGameObjectWithTag("player").transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
        buscando = true;
        renderer = GetComponent<SpriteRenderer>();
        activado = false;
        maxLife = life;
        velocidadInicial = velocidad;
	}

    // Update is called once per frame
    void FixedUpdate () {

        if (turnosParaSalto >= turnosNecesariosParaSalto)
        {
            gameObject.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            gameObject.GetComponent<ParticleSystem>().Stop();
        }

        if (transformJugador.position.y < -15f)
        {
            if (transformJugador.position.x > 116f)
            {
                activado = true;
                //if (musica == false)
                //{
                //    foreach (var root in GameObject.Find("origen_musica").scene.GetRootGameObjects())
                //    {
                //        Destroy(root);
                //    }
                //    //Destroy(GameObject.Find("origen_musica"));
                //    GameObject.Find("MusicaFinal").GetComponent<AudioSource>().clip = clip;
                //    GameObject.Find("MusicaFinal").GetComponent<AudioSource>().Play();
                //    musica = true;
                //}
            }
        }
        else
        {
            activado = false;
            imgLife.SetActive(false);
        }

        if (activado)
        {
            imgLife.SetActive(true);
            imgLife.GetComponent<Image>().fillAmount = life / maxLife;
            
            if (life <= 0)
            {
                Destroy(GameObject.Find("Audio Source"));
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
            collision.gameObject.GetComponent<Transform>().position = new Vector3(116f, 3.49f, 0f);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            life = maxLife;
            activado = true;
            GetComponentInParent<Transform>().position = new Vector3(153f, -22.1f, 0);
            turnosParaSalto = -1;
            buscando = true;
            rb.velocity = new Vector3(0, 0, 0);
            velocidad = velocidadInicial;
            
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
