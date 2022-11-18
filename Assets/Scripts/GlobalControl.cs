using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl: MonoBehaviour
{
    public int coins;
    public int life;
    public int diamond;
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
