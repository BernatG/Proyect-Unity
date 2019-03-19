using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{

    public void changemenuscene(string scenename)
    {
        Application.LoadLevel(scenename);
    }
}
