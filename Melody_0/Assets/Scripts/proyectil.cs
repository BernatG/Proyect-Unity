using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour {

    public float timeLimit;
    public float vel;

    private Rigidbody2D rb;
    private float time;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
        rb.velocity = new Vector2(vel, 0);
        
        time += Time.deltaTime;
        if (time >= timeLimit) {
            Destroy(this.gameObject);
            time = 0;
        }
	}
}
