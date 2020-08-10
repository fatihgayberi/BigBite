using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    void Update()
    {
        CoinFlip();
    }

    void CoinFlip()
    {
        transform.Rotate(0, 2, 0, Space.World);
    }
}
