using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {



    public float speed = 25f;
    public float maxSpeed = 5f;
    public bool groudead;
    public float jumpPower = 6.5f;

    private Rigidbody2D rb2d;
    private Rigidbody2D rb;
    private CapsuleCollider2D cc;
    private bool jump;

    // Use this for initialization

    //void CollisionEnter2D(Collision2D colisión)
    //{
    //    if (colisión.gameObject.tag == "llave")
    //    {
    //        Destroy(colisión.gameObject);
    //    }
    //}

    void Start () {

        rb = gameObject.GetComponent<Rigidbody2D>();
        cc = gameObject.GetComponent<CapsuleCollider2D>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();

    }
	
    // Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Space) && groudead)
        {
            jump = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            cc.enabled = false;
        }
        else
        {
            cc.enabled = true;
        }

	}
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * speed * h);

        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
        Debug.Log(rb2d.velocity.x);
    }
}
