using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ascensor : MonoBehaviour {

    public float velocidadX;
    public float velocidadY;

    public float pLimiteY;
    public float nLimiteY;
    float posiciónInicial;

    float nx;
    float ny;

    float px;
    float py;

    bool dirección;

    private Rigidbody2D rb;
 	// Use this for initialization
	void Start () {
        px = velocidadX;
        py = velocidadY;

        nx = velocidadX * (-1);
        ny = velocidadY * (-1);

        posiciónInicial = transform.position.y;

        dirección = true;

        rb = gameObject.GetComponent<Rigidbody2D>();
	}

    void MovePlatform(float a, float b) {
        gameObject.transform.position = new Vector3(transform.position.x + (a / 50), transform.position.y + (b / 50), transform.position.z);
        //rb.velocity = new Vector2(a, b);
    }

    // Update is called once per frame
    void Update () {

        if (transform.position.y >= pLimiteY)
        {
            dirección = false;
        }
        else if (transform.position.y <= nLimiteY)
        {
            dirección = true;
        }

        if (dirección)
        {
            MovePlatform(px, py);
        }
        else
        {
            MovePlatform(nx, ny);
        }
	}

}
