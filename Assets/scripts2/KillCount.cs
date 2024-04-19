using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    public static int killValue = 0;
    public static int totalKill = 0;
    private TMP_Text killCount;
    // Start is called before the first frame update
    void Start()
    {
        totalKill = PlayerPrefs.GetInt("totalKill");
        killCount = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
         killCount.text = "Kill:" + killValue;
    }
}
