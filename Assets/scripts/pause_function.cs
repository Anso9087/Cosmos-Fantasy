using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_function : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
            
            
            
        }

        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         Time.timeScale = 1f;
         AbilityPause.isPause = false;
        Debug.Log("Again");

    }

    public void Again2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Again3()
    {
        SceneManager.LoadScene("main_menu_interface");
        SceneManager.LoadScene("Stage1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

  
}
