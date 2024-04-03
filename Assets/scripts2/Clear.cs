using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Clear : MonoBehaviour
{
    public GameObject clearPannel;
    public static bool isPause = false;
    private string [] sceneOption = {"Stage2", "Stage3"};
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
    }
    
    public void ChangeToStage2()
    {
        KillCount.killValue = 0;
        SceneManager.LoadScene(sceneOption[0]);
        Time.timeScale = 1f;
    }
    public void ChangeToStage3()
    {
        KillCount.killValue = 0;
        SceneManager.LoadScene(sceneOption[1]);
        Time.timeScale = 1f;
    }
    public void BackMenu()
    {
        KillCount.killValue = 0;
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
