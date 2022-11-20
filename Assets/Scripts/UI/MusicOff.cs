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
    public bool isOn;

    void Start()
    {
        isOn = true;
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("music") <=1f)
        {
            MusicButton.GetComponent<Image>().sprite = OnMusic;
            audioSrc.enabled = true;
            isOn = true;
        }
        else if (PlayerPrefs.GetInt("music") == 0)
        {
            MusicButton.GetComponent<Image>().sprite = OffMusic;
            audioSrc.enabled = false;
            isOn = false;
        }
    }
    /*public void OffMusicVolume()
    {
        if (!isOn)
        {
            PlayerPrefs.SetInt("music", 0);
        }
        else if (isOn)
        {
            PlayerPrefs.SetInt("music", 1);
        }
    }*/
}
