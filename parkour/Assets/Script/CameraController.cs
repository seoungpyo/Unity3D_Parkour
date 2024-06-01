using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] float rotaitionSpeed = 2f;
    [SerializeField] float distance = 5;
    [SerializeField] float minVerticalAngle = -45;
    [SerializeField] float maxVerticalAngle = 45;

    [SerializeField] Vector2 framingOffset;

    [SerializeField] bool invertX;
    [SerializeField] bool invertY;

    float rotationY;
    float rotationX;

    float invertYVal;
    float invertXVal;

    private void Update()
    {
        invertXVal = (invertX) ? -1 : 1;
        invertYVal = (invertY) ? -1 : 1;

        rotationX -= Input.GetAxis("Mouse Y") * invertYVal * rotaitionSpeed;
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);

        rotationY += Input.GetAxis("Mouse X") * invertXVal * rotaitionSpeed;
        
        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);

        var targetPosition = followTarget.position + new Vector3(framingOffset.x,framingOffset.y,0);

        transform.position = followTarget.position - targetRotation * new Vector3(0, 0, distance);
        transform.rotation = targetRotation;


    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
