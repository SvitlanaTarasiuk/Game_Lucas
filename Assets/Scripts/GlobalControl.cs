using UnityEngine;
using TMPro;


public class GlobalControl: MonoBehaviour
{
    public int coins;
    public int life;
    public int diamond;
    public int silver;
    public int heart;
    public TextMeshProUGUI textCoint;
    public TextMeshProUGUI textDiamond;
    public TextMeshProUGUI textSilver;
    //public GameObject[] objHearts;
    public GameUI gameUI;

    public static new GlobalControl Instantiate;

    void Awake()
    {
       if (Instantiate==null)
        {
            DontDestroyOnLoad(gameObject);
            Instantiate = this;
        }
       else if(Instantiate !=this)
        {
            Destroy(gameObject);
        }
    }
    /*public void ResedData()
    {
        coins = 0;
        life = 5;
        diamond = 0;
        silver = 0;
        heart = 5;
        
    }*/

}


//public void SavePlayer()
//GlobalControl.Instantiate.coins = coins;
//...
//void Start(0
//coins = GlobalControl.Instantiate.coins;
//...

