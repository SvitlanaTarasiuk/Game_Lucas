using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject[] objHearts;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelTheEnd;
    //[SerializeField] private GameObject panelSetting;

    private int heart = 5;
    //private bool Button buttonPause= true;

    public void AddHeart()
    {
        heart++;
        UpdateHeart();
    }

    public void RemuveHeart()
    {
        heart--;
        UpdateHeart();
    }
    void UpdateHeart()
    {
        for (int i = 0; i < 5; i++)
        {
            if (heart > i)
            {
                objHearts[i].SetActive(true);
            }
            else
            {
                objHearts[i].SetActive(false);
            }
        }
    }
    /*public void Pause()
    {
        if(buttonPause)
        Time.timeScale = 0.00001f;
        panelSetting.SetActive(true);
        if else(!buttonPause)
        Time.timeScale = 1;
    }*/
    public void GameOver()
    {
        panelGameOver.SetActive(true);
    }
    public void TheEnd()
    {
        panelTheEnd.SetActive(true);
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
