using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{

    public Canvas menus;
    public Canvas controls;

    void Start()
    {
        menus.gameObject.SetActive(true);
        controls.gameObject.SetActive(false);
    }

    public void changemenuscene(string scenename)
    {
        Application.LoadLevel(scenename);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        menus.gameObject.SetActive(false);
        controls.gameObject.SetActive(true);
    }

    public void Back()
    {
        menus.gameObject.SetActive(true);
        controls.gameObject.SetActive(false);
    }
}
