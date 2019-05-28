using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_god : MonoBehaviour
{

    public float posicionAbismo;

    public int life;
    //private float maxLife;
    //private float fLife;

    public float vel;
    private float run;

    private bool grouded;
    public bool doublejump;
    private bool jump2;
    public float jumpPower = 6.5f;
    [HideInInspector] public bool jefeTocado = false;

    private bool shot;
    private bool tieneLlave;
    public bool boolFinal;
    public string scenename;
    //public Image lifeImg;

    public Transform jugador;
    private Vector2 posJugador;
    private GameObject plataformaIgnorada;
    private GameObject instantiatedProjectile;
    public GameObject projectile;
    public ParticleSystem psSalto;
    public ParticleSystem psMuerte;

    private Rigidbody2D rb;
    public Text text_eliminar_enemigo;
    public Text text_movimiento;
    public Text text_correr;
    //private bool jump;

    // Use this for initialization

    void Start()
    {
        //maxLife = life;
        rb = gameObject.GetComponent<Rigidbody2D>();
        posJugador = new Vector2(jugador.position.x, jugador.position.y);
        run = vel + 3;
        shot = false;
        tieneLlave = false;
        boolFinal = false;

        psSalto = GameObject.Find("psPlayer").GetComponent<ParticleSystem>();
        psMuerte = GameObject.Find("psMuerte").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        psSalto.Stop();
        //fLife = life;
        //lifeImg.fillAmount = fLife / maxLife;

        if (plataformaIgnorada != null)
        {
            if (transform.position.y - (GetComponent<CapsuleCollider2D>().bounds.size.y / 3) > plataformaIgnorada.transform.position.y)
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), plataformaIgnorada.GetComponent<Collider2D>(), false);
            }
        }



        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-vel, rb.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(-run, rb.velocity.y);
            }
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(vel, rb.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(run, rb.velocity.y);

            }
        }
        else if (jefeTocado == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), plataformaIgnorada.GetComponent<Collider2D>(), true);
        }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            GetComponent<CapsuleCollider2D>().enabled = true;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grouded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                grouded = false;
                psSalto.Play();
                GetComponent<AudioSource>().Play();
                GetComponent<Animator>().SetBool("salto", true);
            }
            else
            {
                GetComponent<Animator>().Play("salto", -1, 0);
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                jump2 = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightControl) && shot == true)
        {

            instantiatedProjectile = Instantiate(projectile, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.Euler(0, 0, 0), gameObject.transform);
            if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
            {
                instantiatedProjectile.GetComponent<proyectil_jugador>().vel *= (-2);
            }

        }

        if (rb.position.y < (posicionAbismo))
        {
            AudioSource sonidoMuerte = GameObject.Find("Muerte").GetComponent<AudioSource>();
            GameObject.Find("psMuerte").GetComponent<Transform>().position = gameObject.GetComponent<Transform>().position;
            psMuerte.Play();
            //            sonidoMuerte.volume = GlobalControl.Instance.musicVolume;
            sonidoMuerte.Play();
            psMuerte.Play();
            transform.position = posJugador;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "suelo")
        {
            GetComponent<Animator>().SetBool("salto", false);
            jefeTocado = false;
        }
        else if (collision.gameObject.tag == "enemigo")
        {
            GameObject.Find("psMuerte").GetComponent<Transform>().position = gameObject.GetComponent<Transform>().position;
            psMuerte.Play();
            GameObject.Find("Muerte").GetComponent<AudioSource>().Play();
            transform.position = posJugador;
            //life--;
        }
        else if (collision.gameObject.tag == "llave")
        {
            tieneLlave = true;
            collision.gameObject.SetActive(false);
        }
        else if (tieneLlave == true && collision.gameObject.tag == "puerta")
        {
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "jefe")
        {
            //GameObject.Find("psMuerte").GetComponent<Transform>().position = gameObject.GetComponent<Transform>().position;
            //psMuerte.Play();
            GameObject.Find("Muerte").GetComponent<AudioSource>().Play();
        }

        if (collision.gameObject.tag == "habilidad_doble_salto")
        {
            doublejump = true;
            collision.gameObject.SetActive(false);
            AudioSource sonidoDobleSalto = GameObject.Find("habilidad_sonido").GetComponent<AudioSource>();
            sonidoDobleSalto.volume = GlobalControl.Instance.musicVolume;
            sonidoDobleSalto.Play();
            GameObject.Find("particles_habilidad").GetComponent<ParticleSystem>().Stop();
        }
        else if (collision.gameObject.tag == "habilidad_disparo")
        {
            shot = true;
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "final")
        {
            Application.LoadLevel(scenename);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            grouded = true;
            jump2 = true;
            plataformaIgnorada = collision.gameObject;
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "trigger_mensaje_movimiento")
        {
            for (float i = 0; i < 1; i += 0.01f)
            {
                text_movimiento.transform.localScale = new Vector3(i, i, 0);
            }
            text_movimiento.gameObject.SetActive(true);
        }

        if (coll.gameObject.tag == "trigger_mensaje_eliminar_caminante")
        {
            for (float i = 0; i < 1; i += 0.01f)
            {
                text_eliminar_enemigo.transform.localScale = new Vector3(i, i, 0);
            }
            text_eliminar_enemigo.gameObject.SetActive(true);
        }

        if (coll.gameObject.tag == "trigger_mensaje_correr")
        {
            for (float i = 0; i < 1; i += 0.01f)
            {
                text_correr.transform.localScale = new Vector3(i, i, 0);
            }
            text_correr.gameObject.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "subPlataforma")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.gameObject.transform.parent.gameObject.GetComponent<Collider2D>(), true);
            plataformaIgnorada = collision.gameObject.transform.parent.gameObject;
        }
        else if (collision.gameObject.tag == "suelo")
        {
            grouded = true;
            jump2 = true;
            transform.parent = collision.gameObject.transform;

        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "trigger_mensaje_correr")
        {
            text_correr.gameObject.SetActive(false);
        }

        if (coll.gameObject.tag == "trigger_mensaje_movimiento")
        {
            text_movimiento.gameObject.SetActive(false);
        }

        if (coll.gameObject.tag == "trigger_mensaje_eliminar_caminante")
        {
            text_eliminar_enemigo.gameObject.SetActive(false);
        }

        if (coll.gameObject.tag == "subPlataforma")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), coll.gameObject.transform.parent.gameObject.GetComponent<Collider2D>(), false);
        }

        if (coll.gameObject.tag == "suelo")
        {
            grouded = true;
            jump2 = true;
            transform.parent = null;
            rb.velocity = GetComponentInParent<Rigidbody2D>().velocity;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            grouded = false;
        }
    }
}
