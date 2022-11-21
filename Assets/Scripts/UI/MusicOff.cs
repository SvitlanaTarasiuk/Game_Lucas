using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOff : MonoBehaviour
{
    public Sprite OnMusic;
    public Sprite OffMusic;
    public AudioSource audioSrc;
    public Image MusicButton;
    public Slider slider;
    public bool isOn;
    private float musicVolume = 1f;

    void Start()
    {
        isOn = true;
    }
    void Update()
    {
        if (PlayerPrefs.GetFloat("music")> 0)
        {
            MusicButton.sprite = OnMusic;
            audioSrc.enabled = true;
            isOn = true;
        }
        else 
        {
            MusicButton.sprite = OffMusic;
            audioSrc.enabled = false;
            isOn = false;
        }
    }
    public void OffMusicVolume()
    {
        if (!isOn)
        {
            PlayerPrefs.SetFloat("music", 1);
            slider.value = 1;
            MusicButton.sprite = OnMusic;
            audioSrc.enabled = true;
        }
        else if (isOn)
        {
            PlayerPrefs.SetFloat("music", 0);
            slider.value = 0;
            MusicButton.sprite = OffMusic;
            audioSrc.enabled = false;
        }
        isOn = !isOn;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
        PlayerPrefs.SetFloat("music", vol);
        audioSrc.volume = musicVolume;


    }
}
