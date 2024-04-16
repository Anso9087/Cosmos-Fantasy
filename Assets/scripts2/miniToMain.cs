using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class miniToMain : MonoBehaviour
{
    public GameObject toMainPannel;
    public bool isPause = false;
    private string [] sceneOption = {"Stage2", "Stage3"};
    // Start is called before the first frame update
    void Start()
    {
        toMainPannel.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if(pause_function.GameIsPaused){
            toMainPannel.SetActive(false);
        }
        if(!pause_function.GameIsPaused && isPause){
            toMainPannel.SetActive(true);
        }
    }
     private void OnTriggerEnter2D(Collider2D other){ 
        if (other.gameObject.CompareTag("Player")){
            PauseGame();
        }
     }
     public void PauseGame(){
        toMainPannel.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
        PlayerPrefs.SetFloat("health", playerHealth.maximumHealth);
        PlayerPrefs.SetInt("scoreValue", Score.scoreValue);
        PlayerPrefs.SetFloat("speed", PlayerMovement.speed);
        PlayerPrefs.SetFloat("damage", Bullet.damage);
        PlayerPrefs.SetFloat("fireRate", Shooting.fireRate);
        PlayerPrefs.SetInt("count", 0);
        PlayerPrefs.SetFloat("PlayerX", 0);
        PlayerPrefs.SetFloat("PlayerY",0);
        PlayerPrefs.SetFloat("PlayerZ",0);
    }
}
