using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class start_to_game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene()
    {
        PlayerPrefs.SetFloat("health", 100f);
        PlayerPrefs.SetInt("scoreValue", 0);
        PlayerPrefs.SetFloat("speed", 2f);
        PlayerPrefs.SetFloat("damage", 100);
        PlayerPrefs.SetFloat("fireRate", 0.3f);
        PlayerPrefs.SetFloat("PlayerX", 0);
        PlayerPrefs.SetFloat("PlayerY",1);
        PlayerPrefs.SetFloat("PlayerZ",0);
        PlayerPrefs.SetInt("totalKill", 0);
        SceneManager.LoadScene("Stage1");
        Time.timeScale = 1f;
    }
    public void ChangeInfinite()
    {
        PlayerPrefs.SetFloat("health", 100f);
        PlayerPrefs.SetInt("scoreValue", 0);
        PlayerPrefs.SetFloat("speed", 2f);
        PlayerPrefs.SetFloat("damage", 100);
        PlayerPrefs.SetFloat("fireRate", 0.3f);
        PlayerPrefs.SetFloat("PlayerX", 0);
        PlayerPrefs.SetFloat("PlayerY",0);
        PlayerPrefs.SetFloat("PlayerZ",0);
        PlayerPrefs.SetInt("totalKill", 0);
        SceneManager.LoadScene("Infinite");
         Time.timeScale = 1f;
    }
    public void ChangeToScore(){
        SceneManager.LoadScene("ScoreBoard");
         Time.timeScale = 1f;
    }
}

