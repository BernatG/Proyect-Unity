using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_levels : MonoBehaviour {

    void Start()
    {

    }
    public void changemenuscene(string scenename)
    {
        Application.LoadLevel(scenename);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
