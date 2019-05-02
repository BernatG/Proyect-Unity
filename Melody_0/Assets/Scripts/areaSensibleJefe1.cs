using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaSensibleJefe1 : MonoBehaviour {

    public GameObject jefe;
    public float separacion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(jefe.transform.position.x, jefe.transform.position.y + separacion, jefe.transform.position.z);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //transform.parent.GetComponent<jefeFinal1>().life--;
            jefe.GetComponent<jefeFinal1>().life--;
            //transform.parent.GetComponent<jefeFinal1>().velocidad++;
            jefe.GetComponent<jefeFinal1>().velocidad++;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
                collision.gameObject.GetComponent<Rigidbody2D>().velocity.x * 2
                , 10);
        }
    }
}
