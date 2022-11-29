using UnityEngine;

public class Camera3 : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float sensetyCam= 5;
    Transform cameraTransform;
    private Vector3 deltaPosCam;
    private Vector3 target;

    private void Start()
    {
        cameraTransform = transform;
        deltaPosCam = cameraTransform.position - player.position;
        deltaPosCam.z = -10;
    }

    void Update()
    {
        target = player.transform.position + deltaPosCam;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, target, Time.deltaTime * sensetyCam);
    }
}