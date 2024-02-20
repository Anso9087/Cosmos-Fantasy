using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Audio;

public class background_mute_function : MonoBehaviour
{
    public void backgroundmute(bool boxtick)
    {
        if (boxtick)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
    }
    
        
    
}
