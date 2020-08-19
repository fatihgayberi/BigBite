using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    void Update()
    {
        ObjectFlip();
    }

    void ObjectFlip()
    {
        transform.Rotate(0, 2, 0, Space.World);
    }
}
