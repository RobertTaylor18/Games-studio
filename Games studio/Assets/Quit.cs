using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
  
    void Start()
    {
        ExitGame();
    }

    void Update()
    {

    }

    void ExitGame()
    {
        Application.Quit();
    }
}
