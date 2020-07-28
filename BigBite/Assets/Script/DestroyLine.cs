using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLine : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z - 11.5f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Sea"))
        {
            Destroy(collision.gameObject);
        }
    }
}
