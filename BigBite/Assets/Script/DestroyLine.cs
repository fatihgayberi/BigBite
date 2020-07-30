using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLine : MonoBehaviour
{
    // geride kalan objeleri ekrandan temizler
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
