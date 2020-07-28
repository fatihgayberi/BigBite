using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkCreate : MonoBehaviour
{
    Shark shark;
    public GameObject[] sharkArray;
    GameObject sharkPlayer;
    int sharkIndex;

    void Start()
    {
        shark = FindObjectOfType<Shark>();
        sharkIndex = 1;
        CreatePlayer(sharkIndex);
    }

    void CreatePlayer(int sharkIndex)
    {
        sharkPlayer =  Instantiate(sharkArray[sharkIndex], new Vector3(0, 0.5f, 0), Quaternion.Euler(new Vector3(-90, -90, 0)));
        transform.parent = shark.transform;
    }

    public GameObject getSharkPlayer()
    {
        return sharkPlayer;
    }
}
