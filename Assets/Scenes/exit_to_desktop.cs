using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exittodesktop : MonoBehaviour
{
    public void Quitgame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
