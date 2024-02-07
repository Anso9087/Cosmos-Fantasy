using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPause : MonoBehaviour
{
    public GameObject abilityPause;
    public static bool isPause = false;
    public static bool shouldPause = true;
    private List<string> abilityOption = new List<string>{"Increase health capicity", "Increase move speed", "Increase bullet speed"};
    // Start is called before the first frame update
    void Start()
    {
        abilityPause.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(KillCount.killValue % 5 == 0 && KillCount.killValue!=0 && shouldPause){
            PauseGame();
        }
        if (KillCount.killValue % 5 != 0){
            shouldPause = true;
        }
    }
    public void PauseGame(){
        abilityPause.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }
    public void ResumeGame(){
        abilityPause.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
        shouldPause = false;
    }
    public void BuffAbility1(){
        if (string.Equals(Option1Text.abilityChoose, "Increase health capicity")){
            playerHealth.maximumHealth += 50f;
            playerHealth.health = playerHealth.maximumHealth;
            ResumeGame();
            Option1Text.ableRandom = true;
        }
        if (string.Equals(Option1Text.abilityChoose, "Increase move speed")){
            PlayerMovement.speed += 1;
            ResumeGame();
            Option1Text.ableRandom = true;
        }
        if (string.Equals(Option1Text.abilityChoose, "Increase bullet speed")){
            Shooting.fireRate -= 0.1f;
            ResumeGame();
            Option1Text.ableRandom = true;
        }
    }
    public void BuffAbility2(){
        if (string.Equals(Option1Text.abilityChoose, "Increase health capicity")){
            playerHealth.maximumHealth += 50f;
            playerHealth.health = playerHealth.maximumHealth;
            ResumeGame();
            Option2Text.ableRandom = true;
        }
        if (string.Equals(Option1Text.abilityChoose, "Increase move speed")){
            PlayerMovement.speed += 1;
            ResumeGame();
            Option2Text.ableRandom = true;
        }
        if (string.Equals(Option1Text.abilityChoose, "Increase bullet speed")){
            Shooting.fireRate -= 0.1f;
            ResumeGame();
            Option2Text.ableRandom = true;
        }
    }



}
