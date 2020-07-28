using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCamera : MonoBehaviour
{
    Shark shark;
    // Start is called before the first frame update
    void Start()
    {
        shark = FindObjectOfType<Shark>();
    }

    // Update is called once per frame
    void Update()
    {
        CameraPosition();
    }

    void CameraPosition()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, shark.getShark().transform.position.z);
    }
}
