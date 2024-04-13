using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class triggerer : MonoBehaviour
{
    public GameObject minigamePannel;
    public bool isPause = false;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        minigamePannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(pause_function.GameIsPaused){
                minigamePannel.SetActive(false);
        }

        if(isPause && Input.GetKey("q")){
            minigamePannel.SetActive(false);
            Time.timeScale = 1f;
            isPause = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other){ 
        if (other.gameObject.CompareTag("Player")){
            PauseGame();
        }
     }
    public void PauseGame(){
        if(count==0){
            minigamePannel.SetActive(true);
            Time.timeScale = 0f;
            isPause = true;
            PlayerPrefs.SetFloat("health", playerHealth.health);
            PlayerPrefs.SetInt("scoreValue", Score.scoreValue);
            PlayerPrefs.SetFloat("speed", PlayerMovement.speed);
            PlayerPrefs.SetFloat("damage", Bullet.damage);
            PlayerPrefs.SetFloat("fireRate", Shooting.fireRate);
        }
    }
    public void ChangeToSS()
    {
        if(count == 0){
            count = 1;
            PlayerPrefs.SetInt("count", count);
            SceneManager.LoadScene("tiny but many food");
            Time.timeScale = 1f;
        }
    }
    public void ChangeToPP()
    {
        if(count == 0){
            count = 1;
            PlayerPrefs.SetInt("count", count);
            SceneManager.LoadScene("AIvsMen");
            Time.timeScale = 1f;
        }
    }
    public void ResumeGame(){
        minigamePannel.SetActive(false);
        if(count == 0){
            Score.scoreValue+=500;
            count = 1;
        }
        Time.timeScale = 1f;
        isPause = false;
    }
}
