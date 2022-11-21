using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public AudioSource audioSrc;
    private float musicVolume = 1f;

    public void SetVolume(float vol)
    {       
        musicVolume = vol;
        PlayerPrefs.SetFloat("music", vol);
        audioSrc.volume = musicVolume;
    }
   
            
 
    
}
