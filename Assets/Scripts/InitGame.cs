using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
