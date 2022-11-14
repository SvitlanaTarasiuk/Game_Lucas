using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera4 : MonoBehaviour
{
    [SerializeField] private Transform player;          //об'єкт-ціль
    [SerializeField] private float sensetyCam = 5;      //швидкість переміщення
    Transform cameraTransform;                          //камера
    private Vector3 deltaPosCam;                        //зміщення
    private Vector3 target;                             //ціль
    //private float pointX2 = -4f;
    [SerializeField] private float pointX1 = 18f;
    [SerializeField] private float pointY = -0.6f;
    private void Start()
    {    
        cameraTransform = transform;
        deltaPosCam = cameraTransform.position - player.position;
        deltaPosCam.z = -10;
    }
    void Update()
    {
        //if (player.position.x > pointX2 && transform.position.x < pointX1)
        if (player.position.x < pointX1)
        {
            target = player.transform.position + deltaPosCam;
            target.y = pointY;
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, target, Time.deltaTime * sensetyCam);
        }
    }
}
