using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class gameoverui : MonoBehaviour
{
    public GameObject gameOverUI;
   

    

    private void Update()
    {
        // Hide the game over UI at the beginning
        gameOverUI.SetActive(false);
        if (playerHealth.health == 0f)
        {
            GameOver();



        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }
}