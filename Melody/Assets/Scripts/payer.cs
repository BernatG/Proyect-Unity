using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class payer : MonoBehaviour {

    public float velocity = 0.0f;
    public float jump = 0.0f;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {

            rb.velocity = new Vector2( velocity, rb.velocity.y);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {

            rb.velocity = new Vector2( -velocity, rb.velocity.y);
        }
        else {
            
            rb.velocity = new Vector2( 0, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {

            rb.velocity = new Vector2( rb.velocity.y, jump);
        }

	}
}
