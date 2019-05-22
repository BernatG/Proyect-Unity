using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaSensibleJefe1 : MonoBehaviour {

    public GameObject jefe;
    public float separacionY;
    public float separacionX;
    Vector3 separacion;
	// Use this for initialization
	void Start () {
        separacion = new Vector3(transform.position.x - jefe.transform.position.x, transform.position.y - jefe.transform.position.y, transform.position.z - jefe.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = jefe.transform.position + separacion;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //transform.parent.GetComponent<jefeFinal1>().life--;
            jefe.GetComponent<jefeFinal1>().life--;
            //transform.parent.GetComponent<jefeFinal1>().velocidad++;
            jefe.GetComponent<jefeFinal1>().velocidad++;
            collision.gameObject.GetComponent<player>().jefeTocado = true;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
                Random.Range(-10f, 10f),
                10);
        }
    }
}
