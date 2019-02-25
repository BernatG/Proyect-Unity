using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caminante : MonoBehaviour {

    public float vel;
    public bool cosa;
    /// <summary>
    // /////////////////////////////////////////////////////////
    /// </summary>
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(vel, 0);
	}
}
