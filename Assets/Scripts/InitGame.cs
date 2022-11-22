using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    void Start()
    {
        Transform player = SingletoneHero.singletoneHero.transform;
        player.position = GameObject.Find("StartPoint").transform.position;
        Camera.main.GetComponent<CameraController>().InitCam(player);
    }       
}
