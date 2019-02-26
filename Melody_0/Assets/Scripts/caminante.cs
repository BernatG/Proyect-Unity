using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caminante : MonoBehaviour {

    public float vel;

    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(vel, 0);
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "limite")
        {
            vel *= (-1); 
        }

        if (collider.gameObject.tag == "player") {
            Destroy(collider.gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player") {
            Destroy(this.gameObject);
        }
    }
}
