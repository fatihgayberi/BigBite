﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkCreate : MonoBehaviour
{
    public GameObject[] sharkArray;
    GameObject sharkPlayer;
    int sharkIndex;

    void Start()
    {
        sharkIndex = 2;
        CreatePlayer(sharkIndex);
    }

    // shark oluşturur
    void CreatePlayer(int sharkIndex)
    {
        sharkPlayer =  Instantiate(sharkArray[sharkIndex], new Vector3(0, 0.5f, 0), Quaternion.Euler(new Vector3(-90, -90, 0)));
        transform.parent = sharkPlayer.transform;
    }

    // oluşturulan sharki  return eder
    public GameObject getSharkPlayer()
    {
        return sharkPlayer;
    }
}