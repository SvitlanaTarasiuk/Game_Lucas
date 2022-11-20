using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject[] objHearts;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelTheEnd;
    [SerializeField] private GameObject panelSetting;

    [SerializeField] private TextMeshProUGUI textCoin;
    [SerializeField] private TextMeshProUGUI textDiamond;
    [SerializeField] private TextMeshProUGUI textSilver;
    [SerializeField] private int idLevel;
    private int heart = 5;


    /*void Start()
    {
        heart = GlobalControl.Instantiate.heart;
        textCoin.text= GlobalControl.Instantiate.textCoin.text;
        textDiamond.text = GlobalControl.Instantiate.textDiamond.text;
        textSilver.text = GlobalControl.Instantiate.textSilver.text;
    }
    public void SavePlayer()
    {
        GlobalControl.Instantiate.coins = heart;
        GlobalControl.Instantiate.textCoint.text=textCoint.text;
        GlobalControl.Instantiate.textDiamond.text = textDiamond.text;
        GlobalControl.Instantiate.textSilver.text = textSilver.text;
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
    public void SetCountCoinUI(int countCoin)
    {
        textCoin.text = countCoin.ToString();
    }
    public void SetCountDiamondUI(int countDiamond)
    {
        textDiamond.text = countDiamond.ToString();
    }
    public void SetCountSilverUI(int countSilver)
    {
        textSilver.text = countSilver.ToString();
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
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(idLevel);
        Time.timeScale = 1;
    }
    
}
