using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPause : MonoBehaviour
{
    public GameObject abilityPause;
    public static bool isPause = false;
    public static bool shouldPause = true;
    // Start is called before the first frame update
    void Start()
    {
        abilityPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(KillCount.killValue % 5 == 0 && KillCount.killValue!=0 && shouldPause){
            PauseGame();
            if (Input.GetKeyDown(KeyCode.Escape)){
                ResumeGame();
                shouldPause = false;
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
    }
}
