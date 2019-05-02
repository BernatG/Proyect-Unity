using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour {

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

    private bool shot;
    private bool tieneLlave;
    public bool boolFinal;
    public string scenename;
    //public Image lifeImg;

    private GameObject plataformaIgnorada;
    private GameObject instantiatedProjectile;
    public GameObject projectile;
   
    private Rigidbody2D rb;
    public Text text_eliminar_enemigo;
    //private bool jump;

    // Use this for initialization

    void Start () {
        //maxLife = life;
        rb = gameObject.GetComponent<Rigidbody2D>();

        run = vel + 3;
        shot = false;
        tieneLlave = false;
        boolFinal = false;
    }
	
    // Update is called once per frame
	void Update ()
    {
        //fLife = life;
        //lifeImg.fillAmount = fLife / maxLife;

        if (plataformaIgnorada != null)
        {
            if (transform.position.y - (GetComponent<CapsuleCollider2D>().bounds.size.y / 3) > plataformaIgnorada.transform.position.y)
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), plataformaIgnorada.GetComponent<Collider2D>(), false);
            }
        }


        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-vel, rb.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(-run, rb.velocity.y);
            }
        }
        
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(vel, rb.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(run, rb.velocity.y);
                
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //cc.enabled = false;
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), plataformaIgnorada.GetComponent<Collider2D>(), true);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (grouded) {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                grouded = false;
            }
            else if (jump2 == true && doublejump == true) {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                jump2 = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightControl) && shot == true) {

            instantiatedProjectile = Instantiate(projectile, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.Euler(0, 0, 0), gameObject.transform);
            if (gameObject.GetComponent<SpriteRenderer>().flipX == true) {
                instantiatedProjectile.GetComponent<proyectil_jugador>().vel *= (-2);
            }               
            
        }

        if (life <= 0 || rb.position.y < (posicionAbismo)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemigo")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //life--;
        }
        if (collision.gameObject.tag == "llave")
        {
            tieneLlave = true;
            collision.gameObject.SetActive(false);
        }
        if (tieneLlave == true && collision.gameObject.tag == "puerta")
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "habilidad_doble_salto")
        {
            doublejump = true;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "habilidad_disparo")
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
    private void OnTriggerEnter2D(Collider2D coll) {

        if (coll.gameObject.tag == "trigger_mensaje_eliminar_caminante")
        {
            for (float i = 0; i < 1; i += 0.01f)
            {
                text_eliminar_enemigo.transform.localScale = new Vector3(i, i, 0);
            }
            
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
        if (coll.gameObject.tag == "trigger_mensaje_eliminar_caminante")
        {
            text_eliminar_enemigo.gameObject.SetActive(false);
        }
        else if (coll.gameObject.tag == "subPlataforma")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), coll.gameObject.transform.parent.gameObject.GetComponent<Collider2D>(), false);
        }
        else if (coll.gameObject.tag == "suelo")
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
