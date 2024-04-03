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
    public static string ability1=null;
    public static string ability2=null;
    private string [] abilityOption = {"Increase health capicity", "Increase move speed", "Increase bullet speed", "Increase damage"};
    // Start is called before the first frame update
    void Start()
    {
        abilityPause.SetActive(false);
        Shuffle(abilityOption);
    }

    // Update is called once per frame
    void Update()
    {
        if(KillCount.killValue % 5 == 0 && KillCount.killValue!=0 && shouldPause){
            PauseGame();
            if(pause_function.GameIsPaused){
                abilityPause.SetActive(false);
            }else{
                PauseGame();
            }
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
        Shuffle(abilityOption);
        Option1Text.count = 0;
        Option2Text.count = 0;
    }
    public void AddScore(){
        Score.scoreValue += 500;
        ResumeGame();
    }
    public void BuffAbility1(){
        if (string.Equals(Option1Text.abilityChoose, "Increase health capicity")){
            playerHealth.maximumHealth += 50f;
            playerHealth.health = playerHealth.maximumHealth;
            ResumeGame();
        }
        if (string.Equals(Option1Text.abilityChoose, "Increase move speed")){
            PlayerMovement.speed += 1;
            ResumeGame();
        }
        if (string.Equals(Option1Text.abilityChoose, "Increase bullet speed")){
            Shooting.fireRate -= 0.1f;
            ResumeGame();
        }
        if (string.Equals(Option1Text.abilityChoose, "Increase damage"))
        {
            Bullet.damage += 5f;
            ResumeGame();
            }
    }
    public void BuffAbility2()
    {
        if (string.Equals(Option2Text.abilityChoose, "Increase health capicity"))
        {
            playerHealth.maximumHealth += 50f;
            playerHealth.health = playerHealth.maximumHealth;
            ResumeGame();
        }
        if (string.Equals(Option2Text.abilityChoose, "Increase move speed"))
        {
            PlayerMovement.speed += 1;
            ResumeGame();
        }
        if (string.Equals(Option2Text.abilityChoose, "Increase bullet speed"))
        {
            Shooting.fireRate -= 0.1f;
            ResumeGame();
        }
        if (string.Equals(Option2Text.abilityChoose, "Increase damage"))
        {
            Bullet.damage += 5f;
            ResumeGame();
            }
    }
    public void Shuffle(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            string tmp = array[i];
            int rand = UnityEngine.Random.Range(0, array.Length);
            array[i] = array[rand];
            array[rand] = tmp;
        }
        ability1 = abilityOption[0];
        ability2 = abilityOption[1];
    }

}
