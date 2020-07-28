using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCamera : MonoBehaviour
{
    Shark shark;
    SharkCreate sharkCreate;
    // Start is called before the first frame update
    void Start()
    {
        sharkCreate = FindObjectOfType<SharkCreate>();
        shark = FindObjectOfType<Shark>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraPosition();
    }

    void CameraPosition()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, sharkCreate.getSharkPlayer().transform.position.z);
    }
}
