using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class again_score_killcount_player : MonoBehaviour
{
    public Button restartbutton;
    
    void Start()
    {
        Button btn = restartbutton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    
    void TaskOnClick()
    {
        if (restartbutton.interactable)
        {
            Score.scoreValue = 0;
            KillCount.killValue = 0;
            playerHealth.health = playerHealth.maximumHealth;
        }
    }

    
}
