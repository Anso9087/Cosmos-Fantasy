using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class clearMessage : MonoBehaviour
{
    private TMP_Text message;
    // Start is called before the first frame update
    void Start()
    {
        message = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        message.text = "Total Score: " + PlayerPrefs.GetInt("scoreValue") + " Total Kill: " + PlayerPrefs.GetInt("totalKill");
    }
}
