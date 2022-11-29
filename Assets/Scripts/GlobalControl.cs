using UnityEngine;
using TMPro;


public class GlobalControl: MonoBehaviour
{
    public int coins;
    public int life;
    public int diamond;
    public TextMeshProUGUI textCoint;
    public TextMeshProUGUI textDiamond;
    public TextMeshProUGUI textSilver;
    public int heart;
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
}
//public int coins;
//public int life;
//public int diamond;
//public TextMeshProUGUI textCoint;
//public TextMeshProUGUI textDiamond;
//public TextMeshProUGUI textSilver;
//public int heart;
//public GameUI gameUI;

//public void SavePlayer()
//Clobal.Control.Instantiate.coins = coins;
//...
//void Start(0
//coins = Clobal.Control.Instantiate.coins;
//...

