using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{

    private Transform situacion;
    private GameObject jugador;
    private float jugadorPosX;
    private float jugadorPosY;
    public Canvas canvas;

    // Use this for initialization
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("player");
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;

        //jugadorPosX = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>().position.x;
        //jugadorPosY = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>().position.y;
    }

    // Update is called once per frame
    void Update()
    {
        jugadorPosX = jugador.transform.position.x;
        jugadorPosY = jugador.transform.position.y;
        gameObject.transform.position = new Vector3(jugadorPosX, jugadorPosY + 1.5f, gameObject.transform.position.z);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                canvas.gameObject.SetActive(true);

            }
            else
            {
                Time.timeScale = 1;
                canvas.gameObject.SetActive(false);
            }
        }
    }
}
