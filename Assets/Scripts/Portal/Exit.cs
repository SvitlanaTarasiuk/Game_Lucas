using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
   [SerializeField] private int idLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(idLevel);
            //SceneManager.GetActiveScene();
        }
    }
}