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

   void Start()
    {
        print("StartUI");
        heart = GlobalControl.Instantiate.heart;
        textCoin = GlobalControl.Instantiate.textCoint;
        textDiamond = GlobalControl.Instantiate.textDiamond;
        textSilver = GlobalControl.Instantiate.textSilver;
        //objHearts = GlobalControl.Instantiate.objHearts;
    }
    public void SaveUI()
    {
        GlobalControl.Instantiate.heart = heart;
        GlobalControl.Instantiate.textCoint = textCoin;
        GlobalControl.Instantiate.textDiamond = textDiamond;
        GlobalControl.Instantiate.textSilver = textSilver;
        //GlobalControl.Instantiate.objHearts = objHearts;

    }
    public void AddHeart()
    {
        heart++;
        //SaveUI();
        UpdateHeart();
    }
    public void RemuveHeart()
    {
        heart--;
        //SaveUI();
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
    /*public void SetCountLifeUI(int life)
    {
        heart = life;
        UpdateHeart();
    }*/
    public void SetCountCoinUI(int countCoin)
    {   
        textCoin.text = countCoin.ToString();
        
    }
    public void SetCountDiamondUI(int countDiamond)
    {   //SaveUI();
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
        print("GameOverDestroy");
        panelGameOver.SetActive(true);
    }
    public void TheEnd()
    {
        print("TheEnd");

        panelTheEnd.SetActive(true);
    }
    public void NewGame()
    {
        print("NewGame");

        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        //SingletoneHero._singletoneHero.GetComponent<Hero>().NewStartParametr();

    }
    /*public void Restart()
    {
        print("Restart");
        SceneManager.LoadScene(idLevel);
        Time.timeScale = 1;      
    }*/

}
