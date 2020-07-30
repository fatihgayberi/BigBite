using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkCreate : MonoBehaviour
{
    public GameObject[] sharkArray; // shark prefablarini tutar
    public List<Shark> shark = new List<Shark>(); // sharklarin ozelliklerini tutan list
    GameObject sharkPlayer;
    int sharkIndex;

    void Start()
    {
        sharkIndex = 1;
        SharkAdd();
        CreatePlayer(sharkIndex);
    }

    void SharkAdd()
    {
        shark.Add(new Shark(sharkArray[0], 100f, 2f, 2f, 4f, 1));
        shark.Add(new Shark(sharkArray[1], 150f, 2.5f, 4f, 5f, 2));
        shark.Add(new Shark(sharkArray[2], 200f, 3f, 6f, 6f, 3));
        shark.Add(new Shark(sharkArray[3], 250f, 3.5f, 8f, 7f, 4));
        shark.Add(new Shark(sharkArray[4], 300f, 4f, 10f, 8f, 5));
    }

    // shark oluşturur
    void CreatePlayer(int sharkIndex)
    {
        sharkPlayer =  Instantiate(shark[sharkIndex].getSharkObject(), new Vector3(0, 0.5f, 0), Quaternion.Euler(new Vector3(-90, -90, 0)));
        transform.parent = sharkPlayer.transform;
    }

    // oluşturulan sharki  return eder
    public GameObject getSharkPlayer()
    {
        return sharkPlayer;
    }
}
