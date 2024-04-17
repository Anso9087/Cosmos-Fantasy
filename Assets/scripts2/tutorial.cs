using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject tutorials;
    // Start is called before the first frame update
    void Start()
    {
        tutorials.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("q")){
            tutorials.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
