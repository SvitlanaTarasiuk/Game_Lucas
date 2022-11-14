using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    [SerializeField] private GameUI gameUI;
    private int keyForTheEnd=1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Hero heroPlayer = collision.GetComponent<Hero>();
            if (heroPlayer.Key == keyForTheEnd)
            {
                //sprint("Portal");
                Time.timeScale = 0;
                gameUI.TheEnd();
                
            }
        }
    }

}

