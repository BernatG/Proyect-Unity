using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caminante : MonoBehaviour
{

    public float vel = 0;
    public int daño = 0;

    public GameObject enemyParticle;

    private Rigidbody2D rb;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(vel, 0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "limite")
        {
            vel *= (-1);
        }

        if (collider.gameObject.tag == "proyectil_jugador")
        {
            Destroy(collider.gameObject);
            Destroy(this.gameObject);
        }

        if (collider.gameObject.tag == "player")
        {
            enemyParticle.GetComponent<ParticleSystem>().Play();
            gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
        
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            player.GetComponent<player>().life -= daño;
        }
    }*/
}
