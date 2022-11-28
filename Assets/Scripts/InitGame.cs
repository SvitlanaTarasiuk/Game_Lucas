using UnityEngine;

public class InitGame : MonoBehaviour
{
    void Start()
    {
            print("InitGame");     
            Transform player = SingletoneHero.singletoneHero.transform;
            player.position = GameObject.Find("StartPoint").transform.position;
            Camera.main.GetComponent<CameraController>().InitCam(player);     
    }       
}
