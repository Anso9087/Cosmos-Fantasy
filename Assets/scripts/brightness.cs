using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brightness : MonoBehaviour
{
    public Slider light_Slider;
    public Light sceneLight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sceneLight.intensity = light_Slider.value;
    }
}
