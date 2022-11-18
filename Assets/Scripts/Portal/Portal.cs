using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private int idNextLevel;
    private int keyForNextLevel=1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Hero heroPlayer = collision.GetComponent<Hero>();
            if (heroPlayer.Key == keyForNextLevel)
            {
                print("Portal");
                SceneManager.LoadScene(idNextLevel);
            }
        }
    }  
}
