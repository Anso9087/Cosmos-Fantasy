using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    private TMP_Text score;
    // Start is called before the first frame update

    void Start()
    {
        scoreValue =  PlayerPrefs.GetInt("scoreValue");
        score = GetComponent<TMP_Text>();
    }
     

    // Update is called once per frame
    void Update()
    {
        score.text = "Score:" + scoreValue;
        

    }
    
    }
