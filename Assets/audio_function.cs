using UnityEngine.Audio;
using UnityEngine;

public class audio_function : MonoBehaviour
{
    public AudioMixer main_mixer;
    public void set_background_volume(float bv)
    {
        main_mixer.SetFloat("background volume", bv);
    }
        
    
}
