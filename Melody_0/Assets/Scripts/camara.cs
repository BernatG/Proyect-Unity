using UnityEngine;


public class camara : MonoBehaviour
{

    private Transform posicionJugador;

    public float velocidad = 0.125f;
    public Vector3 distancia;
    public player Player;

    //private GameObject jugador;

    //private float jugadorPosX;
    //private float jugadorPosY;
    public Canvas canvas;

    // Use this for initialization
    void Start()
    {
        posicionJugador = GameObject.FindGameObjectWithTag("player").transform;
        distancia.z = -1;
        canvas.gameObject.SetActive(false);
        //Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
   
        /*
        jugadorPosX = jugador.transform.position.x;
        jugadorPosY = jugador.transform.position.y;
        gameObject.transform.position = new Vector3(jugadorPosX, jugadorPosY + 1.5f, gameObject.transform.position.z);
        */
        if (Input.GetKeyDown(KeyCode.Escape) && Player.boolFinal == false)
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

    private void FixedUpdate()
    {
        Vector3 posicionFinal = posicionJugador.position + distancia;
        Vector3 posicionCercana = Vector3.Lerp(gameObject.transform.position, posicionFinal, velocidad);
        transform.position = posicionCercana;

        //transform.LookAt(posicionJugador);
    }

    public void Continuar()
    {
        Time.timeScale = 1;
        canvas.gameObject.SetActive(false);
    }
}
