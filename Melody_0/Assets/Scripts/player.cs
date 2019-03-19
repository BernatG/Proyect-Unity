using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {


    public int life;
    public float vel;
    public float run;
    private bool grouded;
    private bool doublejump;
    private bool jump2;
    public float jumpPower = 6.5f;
    private bool shot;
    private bool tieneLlave;

    private GameObject instantiatedProjectile;
    public GameObject projectile;
    private Rigidbody2D rb;
    private CapsuleCollider2D cc;
    //private bool jump;

    // Use this for initialization

    void Start () {
        life = 1;
        rb = gameObject.GetComponent<Rigidbody2D>();
        cc = gameObject.GetComponent<CapsuleCollider2D>();
        run = vel + 3;
        shot = true;
        doublejump = true;
        tieneLlave = false;
    }
	
    // Update is called once per frame
	void Update ()
    {
        //Debug.Log(rb.transform.localScale);
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
            cc.enabled = false;
        }
        else
        {
            cc.enabled = true;
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

        if (life <=0 || rb.position.y < (-5)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "llave")
        {
            tieneLlave = true;
            collision.gameObject.SetActive(false);
        }
        if (tieneLlave == true && collision.gameObject.tag == "puerta")
        {
            collision.gameObject.SetActive(false);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        grouded = true;
        jump2 = true;
    }
    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "enemigo") {
            life--;
        }        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        grouded = false;
    }
}
