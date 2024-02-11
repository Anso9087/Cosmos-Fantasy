using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Option1Text : MonoBehaviour
{
    private List<string> abilityOption = new List<string>{"Increase health capicity", "Increase move speed", "Increase bullet speed"};
    private TMP_Text option1Text;
    public static string abilityChoose = "0";
    public static bool ableRandom = true;
    public static int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        option1Text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        abilityChoose = AbilityPause.ability1;
        option1Text.text = abilityChoose;
    }
}
