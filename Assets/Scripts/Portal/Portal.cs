using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private int idNextLevel;
    private int keyForNextLevel = 1;
    private int key = 0;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Hero heroPlayer = collision.GetComponent<Hero>();
            key = heroPlayer.Key;

            if (key == keyForNextLevel)
            {
                key -= 1;                
                SceneManager.LoadScene(idNextLevel);
            }
        }
    }  
}
