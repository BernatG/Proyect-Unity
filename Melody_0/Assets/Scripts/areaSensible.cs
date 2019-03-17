using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaSensible : MonoBehaviour {

    //private GameObject padre;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
