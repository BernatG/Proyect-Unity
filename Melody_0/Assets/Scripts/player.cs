using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {



    public float vel;
    public float run;
    private bool grouded;
    private bool doublejump;
    private bool jump2;
    public float jumpPower = 6.5f;
    private bool shot;

    private GameObject instantiatedProjectile;
    public GameObject projectile;
    private Rigidbody2D rb;
    private CapsuleCollider2D cc;
    //private bool jump;

    // Use this for initialization

    void Start () {

        rb = gameObject.GetComponent<Rigidbody2D>();
        cc = gameObject.GetComponent<CapsuleCollider2D>();
        run = vel + 3;
        shot = true;
        doublejump = false;
    }
	
    // Update is called once per frame
	void Update ()
    {
        //Debug.Log(rb.transform.localScale);
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-vel, rb.velocity.y);
            rb.transform.localScale = new Vector3(3.3075f, rb.transform.localScale.y, rb.transform.localScale.z);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(-run, rb.velocity.y);
            }
        }
        
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(vel, rb.velocity.y);
            rb.transform.localScale = new Vector3(-3.3075f, rb.transform.localScale.y, rb.transform.localScale.z);
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

        if (Input.GetKeyDown(KeyCode.RightControl) /*&& shot == true*/) {

            /*instantiatedProjectile = Instantiate(projectile, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.Euler(0, 0, 0), gameObject.transform);
            if (rb.transform.localScale.x == -3.3075f) {
                instantiatedProjectile.GetComponent<proyectil_jugador>().vel *= (-1); 
                //instantiatedProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(vel, 0);
            }
            //else
                //instantiatedProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-vel, 0);
            */
        }

	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        grouded = true;
        jump2 = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        grouded = false;
    }
}
