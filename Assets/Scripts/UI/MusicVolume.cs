using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Sprite OnMusic;
    public Sprite OffMusic;
    public AudioSource audioSrc;
    public Image MusicButton;
    private float musicVolume = 1f;
    public bool isOn;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        isOn = true;
    }
    void Update()
    {
        audioSrc.volume = musicVolume;
        if (PlayerPrefs.GetInt("music") == 0)
        {
            MusicButton.GetComponent<Image>().sprite = OnMusic;
            audioSrc.enabled = true;
            isOn = true;
        }
        else if (PlayerPrefs.GetInt("music") == 1)
        {
            MusicButton.GetComponent<Image>().sprite = OffMusic;
            audioSrc.enabled = false;
            isOn = false;
        }
    }
    public void SetVolume(float vol)
    {
        musicVolume = vol;

    }
    public void OffMusicVolume()
    {
        if (isOn)
        {
            PlayerPrefs.GetInt("music", 0);
        }
        else if (!isOn)
        {
            PlayerPrefs.GetInt("music", 1);
        }
    }
}
