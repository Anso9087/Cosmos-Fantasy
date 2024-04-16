using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Clear : MonoBehaviour
{
    public GameObject clearPannel;
    public static bool isPause = false;
    private string [] sceneOption = {"Stage2", "Stage3", "Minigame1", "Minigame2"};
    // Start is called before the first frame update
    void Start()
    {
        clearPannel.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if( getarget() == false){
            if(KillCount.killValue >= 20){
                if(AbilityPause.isPause){
                    clearPannel.SetActive(false); 
                }else{
                PauseGame();
                }
            }
        }
    }
    public void PauseGame(){
        clearPannel.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
        PlayerPrefs.SetFloat("health", playerHealth.maximumHealth);
        PlayerPrefs.SetInt("scoreValue", Score.scoreValue);
        PlayerPrefs.SetFloat("speed", PlayerMovement.speed);
        PlayerPrefs.SetFloat("damage", Bullet.damage);
        PlayerPrefs.SetFloat("fireRate", Shooting.fireRate);
        PlayerPrefs.SetInt("totalKill", KillCount.totalKill);
    }
    
    public void ChangeToStage2()
    {
        KillCount.killValue = 0;
        isPause = false;
        SceneManager.LoadScene(sceneOption[0]);
        Time.timeScale = 1f;
    }
    public void ChangeToStage3()
    {
        KillCount.killValue = 0;
        isPause = false;
        SceneManager.LoadScene(sceneOption[1]);
        Time.timeScale = 1f;
    }
    public void ChangeToMini1()
    {
        PlayerPrefs.SetFloat("PlayerX", -5.36f);
        PlayerPrefs.SetFloat("PlayerY", -0.59f);
        PlayerPrefs.SetFloat("PlayerZ", 0);
        PlayerPrefs.SetInt("count", 0);
        KillCount.killValue = 0;
        isPause = false;
        SceneManager.LoadScene(sceneOption[2]);
        Time.timeScale = 1f;
    }
    public void ChangeToMini2()
    {
        PlayerPrefs.SetFloat("PlayerX", -5.36f);
        PlayerPrefs.SetFloat("PlayerY", -0.59f);
        PlayerPrefs.SetFloat("PlayerZ", 0);
        PlayerPrefs.SetInt("count", 0);
        KillCount.killValue = 0;
        isPause = false;
        SceneManager.LoadScene(sceneOption[3]);
        Time.timeScale = 1f;
    }
    public void BackMenu()
    {
        KillCount.killValue = 0;
        isPause = false;
        HighscoreTable.AddHighscoreEntry(PlayerPrefs.GetInt("scoreValue"), PlayerPrefs.GetInt("totalKill"));
        SceneManager.LoadScene("Main_menu_interface");
        Time.timeScale = 1f;
    }
    private bool getarget(){ // set the target to player when the enemy spawn
        if ( GameObject.FindGameObjectWithTag("Boss")){
            return true;
        }else{
            return false;
        }
        
    }

}
