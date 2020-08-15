using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScene : MonoBehaviour
{
    SharkCreate sharkCreate;

    void Start()
    {
        sharkCreate = FindObjectOfType<SharkCreate>();
    }

    void Update()
    {
        CameraPosition();
    }

    // main camera nin pozisyonunu gunceller
    void CameraPosition()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, sharkCreate.getSharkPlayer().transform.position.z);
    }
}
