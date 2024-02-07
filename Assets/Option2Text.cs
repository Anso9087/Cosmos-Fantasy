using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Option2Text : MonoBehaviour
{
    private List<string> abilityOption = new List<string>{"Increase health capicity", "Increase move speed", "Increase bullet speed"};
    private TMP_Text option2Text;
    public static string abilityChoose = "0";
    public static bool ableRandom = true;
    // Start is called before the first frame update
    void Start()
    {
        option2Text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        while(ableRandom){
            string abilityOption1 = Option1Text.abilityChoose;
            abilityOption.Remove(abilityOption1);
            int randNum = UnityEngine.Random.Range(0, abilityOption.Count);
            abilityChoose = abilityOption[randNum];
            option2Text.text = abilityChoose;
            abilityOption.Add(abilityOption1);
            ableRandom = false;
        }
    }
}
