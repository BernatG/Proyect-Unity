using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {



    public float vel;
    public float run;
    public bool grouded;
    public float jumpPower = 6.5f;

    private Rigidbody2D rb;
    private CapsuleCollider2D cc;
    //private bool jump;

    // Use this for initialization

    void Start () {

        rb = gameObject.GetComponent<Rigidbody2D>();
        cc = gameObject.GetComponent<CapsuleCollider2D>();
        run = vel + 3;
 
    }
	
    // Update is called once per frame
	void Update ()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
             rb.velocity = new Vector2(-vel, rb.velocity.y);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(-run, rb.velocity.y);
            }
        }
        
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(vel, rb.velocity.y);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(run, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        /*if (Input.GetKeyDown(KeyCode.Space) && groudead)
        {
            jump = true;
        }*/

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
        }

	}
    /*void FixedUpdate()
    {
        if (jump)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
        Debug.Log(rb.velocity.x);
    }*/
    private void OnCollisionStay2D(Collision2D collision)
    {
        grouded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        grouded = false;
    }
}
