using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    SharkCreate sharkCreate;
    Transform target;
    Transform childTarget;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 offsetX;

    private void Start()
    {
        sharkCreate = FindObjectOfType<SharkCreate>();
        target = sharkCreate.getSharkPlayer().transform;
        childTarget = sharkCreate.getSharkPlayer().transform.GetChild(0).gameObject.transform;
    }
    void FixedUpdate()
    {
        Vector3 desirdPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirdPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
