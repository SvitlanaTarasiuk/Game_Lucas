using UnityEngine;

public class InitGame : MonoBehaviour
{
    void Awake()
    {
            print("InitGame");     
           // Transform player = SingletoneHero._singletoneHero.transform;
            ///player.position = GameObject.Find("StartPoint").transform.position;
            //Camera.main.GetComponent<CameraController>().InitCam(player);     
    }       
}
