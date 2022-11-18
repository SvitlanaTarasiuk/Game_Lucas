using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject[] objHearts;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelTheEnd;
    [SerializeField] private GameObject panelSetting;
    [SerializeField] private GameObject panelSilver;
    [SerializeField] private int idLevel;
    private int heart = 5;
    

    /*void Start()
    {
        heart = GlobalControl.Instantiate.heart;
        panelGameOver = GlobalControl.Instantiate.panelGameOver;
        diamond = GlobalControl.Instantiate.diamond;
    }
    public void SavePlayer()
    {
        GlobalControl.Instantiate.coins = heart;
        GlobalControl.Instantiate.life = life;
        GlobalControl.Instantiate.diamond = diamond;
    }*/

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
    public void PauseOn()
    {
        Time.timeScale = 0.00001f;
        panelSetting.SetActive(true);
    }
    public void PauseOff()
    {
        Time.timeScale = 1;
        panelSetting.SetActive(false);
    }
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
        //SceneManager.LoadScene(idLevel);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(idLevel);
        Time.timeScale = 1;
    }
    
}
