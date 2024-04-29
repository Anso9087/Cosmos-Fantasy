using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class clearInfinite : MonoBehaviour
{
    public GameObject endInfinite;
    public static bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        endInfinite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.health <= 0f)
        {
            GameOver();



        }
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        endInfinite.SetActive(true);
        isPause = true;
        PlayerPrefs.SetFloat("health", playerHealth.maximumHealth);
        PlayerPrefs.SetInt("scoreValue", Score.scoreValue);
        PlayerPrefs.SetFloat("speed", PlayerMovement.speed);
        PlayerPrefs.SetFloat("damage", Bullet.damage);
        PlayerPrefs.SetFloat("fireRate", Shooting.fireRate);
        PlayerPrefs.SetInt("totalKill", KillCount.totalKill);
    }
    public void BackMenu()
    {
        KillCount.killValue = 0;
        isPause = false;
        SceneManager.LoadScene("Main_menu_interface");
        Time.timeScale = 1f;
    }
     public void Again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        Score.scoreValue = 0;
        AbilityPause.isPause = false;
        Debug.Log("Again");

    }
}
