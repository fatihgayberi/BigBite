using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sea : MonoBehaviour
{
    public GameObject[] seaObjectArray;
    public List<SeaObject> seaObject = new List<SeaObject>();
    int level;
    static float positionZ = 1.5f;

    void Start()
    {
        level = 25;
        LevelAddOject();
        SpawnObject();
    }

    void Update()
    {
        
    }

    void LevelAddOject()
    {
        seaObject.Add(new SeaObject(seaObjectArray[0], 5, 1)); // 0-10 bölüm arası basit bölümlerden oluşacak
        seaObject.Add(new SeaObject(seaObjectArray[1], 10, 2)); // 10 - 15 bölüm arası kutular dahil edilecek
        seaObject.Add(new SeaObject(seaObjectArray[2], 15, 3)); // 15 - 20 bölüm arası mayın dahil edilecek
        seaObject.Add(new SeaObject(seaObjectArray[3], 20, 4)); // 20 -… bölümlerde radyo aktif kutular dahil edilecek ve hepsi karışık gelmeye başlayacak
    }

    void SpawnObject()
    {

        if (level <= 10)
        {
            RandomSeaObjectGenerator(1);
        }
        else if (level <= 15)
        {
            RandomSeaObjectGenerator(2);
        }
        else if(level <= 20)
        {
            RandomSeaObjectGenerator(3);
        }
        else if(level > 20)
        {
            RandomSeaObjectGenerator(4);
        }
    }

    void RandomSeaObjectGenerator(int lvl)
    {
        for (int i = 0; i < 3; i++)
        {
            //Instantiate(seaObject[Random.Range(0, 3)].getSeaGameObject(), new Vector3(Random.Range(-10.0f, 10.0f), 0.3f, i), Quaternion.identity);
            //Instantiate(seaObject[2].getSeaGameObject(), new Vector3(Random.Range(-1, 2), 0.3f, positionZ), Quaternion.identity);
            Instantiate(seaObject[Random.Range(0, lvl)].getSeaGameObject(), new Vector3(Random.Range(-1f, 1f), 0.3f, positionZ), Quaternion.identity);
            positionZ += 2f;
        }
    }
}
