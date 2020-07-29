using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sea : MonoBehaviour
{
    public GameObject[] seaObjectArray; // unity uzerinden engeller eklenir
    public List<SeaDamageObject> seaObject = new List<SeaDamageObject>(); // engellerin ozelliklerini tutan list
    int level; // oyuncunun levelini tutar
    static float positionZ = 1.5f; // engellerin ilerleyecek bi sekilde olusmasi icin z duzleminin pozisyonunu tutar

    void Start()
    {
        level = 25;
        LevelAddOject();
        SpawnObject();
    }

    void Update()
    {
        
    }

    // engelleri list e ekler
    void LevelAddOject()
    {
        seaObject.Add(new SeaDamageObject(seaObjectArray[0], 5, 1)); // 0-10 bölüm arası basit bölümlerden oluşacak
        seaObject.Add(new SeaDamageObject(seaObjectArray[1], 10, 2)); // 10 - 15 bölüm arası kutular dahil edilecek
        seaObject.Add(new SeaDamageObject(seaObjectArray[2], 15, 3)); // 15 - 20 bölüm arası mayın dahil edilecek
        seaObject.Add(new SeaDamageObject(seaObjectArray[3], 20, 4)); // 20 -… bölümlerde radyo aktif kutular dahil edilecek ve hepsi karışık gelmeye başlayacak
    }

    // level seviyesine gore spawn edilecek olan engelli belirler
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

    // randrom olarak engeller olusturur
    void RandomSeaObjectGenerator(int lvl)
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(seaObject[Random.Range(0, lvl)].getSeaGameObject(), new Vector3(Random.Range(-1f, 1f), 0.3f, positionZ), Quaternion.identity);
            positionZ += 2f;
        }
    }
}
