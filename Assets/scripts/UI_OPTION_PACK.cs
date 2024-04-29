using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_OPTION_PACK : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeToScore()
    {
        SceneManager.LoadScene("ScoreBoard");
        Time.timeScale = 1f;
    }
}
