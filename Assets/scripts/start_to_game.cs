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
        playerHealth.health = 100f;
        Bullet.damage = 100;
        Score.scoreValue = 0;
        Shooting.fireRate = 0.3f;
        PlayerMovement.speed = 2f;
        SceneManager.LoadScene("Stage1");
    }
}

