using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    private float speed;
    private Vector3 offset;

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;

        Vector3 resultPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime *speed);
        transform.position =resultPosition;

    }
}
