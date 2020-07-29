using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCamera : MonoBehaviour
{
    Shark shark;
    SharkCreate sharkCreate;

    void Start()
    {
        sharkCreate = FindObjectOfType<SharkCreate>();
        shark = FindObjectOfType<Shark>();
    }

    void Update()
    {
        CameraPosition();
    }

    void CameraPosition()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, sharkCreate.getSharkPlayer().transform.position.z);
    }
}
