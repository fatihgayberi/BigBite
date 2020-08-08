﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sea : MonoBehaviour
{
    public GameObject[] seaDamageObjectArray; // unity uzerinden engeller eklenir
    public GameObject[] seaAdvantageObjectArray; // unity uzerinden engeller eklenir
    public List<SeaDamageObject> seaDamageObject = new List<SeaDamageObject>(); // engellerin ozelliklerini tutan list
    public List<SeaAdvantageObject> seaAdvantageObject = new List<SeaAdvantageObject>(); // engellerin ozelliklerini tutan list
    public GameObject coin; // oyundaki altini tutar unity uzerinden eklenir

    SharkCreate sharkCreate;

    int level; // oyuncunun levelini tutar
    public static float damagePositionZ; // engellerin ilerleyecek bi sekilde olusmasi icin z duzleminin pozisyonunu tutar
    static float advantageFishPositionZ; // advantage objelerinin ilerleyecek bi sekilde olusmasi icin z duzleminin pozisyonunu tutar
    static float advantageCoinPositionZ;

    void Start()
    {
        sharkCreate = FindObjectOfType<SharkCreate>();
        level = 25;
        //advantageFishPositionZ = damagePositionZ;
        //advantageCoinPositionZ = damagePositionZ;
        LevelAddOject();
        SpawnDamageObject();
        SpawnAdvantageObject();
        CoinCreate();
    }

    private void Update()
    {
        PositionControlZ();
    }

    // engelleri list e ekler
    void LevelAddOject()
    {
        // damage ogelerini ekler
        seaDamageObject.Add(new SeaDamageObject(seaDamageObjectArray[0], 5, 1)); // 0-10 bölüm arası basit bölümlerden oluşacak
        seaDamageObject.Add(new SeaDamageObject(seaDamageObjectArray[1], 10, 2)); // 10 - 15 bölüm arası kutular dahil edilecek
        seaDamageObject.Add(new SeaDamageObject(seaDamageObjectArray[2], 15, 3)); // 15 - 20 bölüm arası mayın dahil edilecek
        seaDamageObject.Add(new SeaDamageObject(seaDamageObjectArray[3], 20, 4)); // 20 -… bölümlerde radyo aktif kutular dahil edilecek ve hepsi karışık gelmeye başlayacak

        // advantage ogelerini ekler
        seaAdvantageObject.Add(new SeaAdvantageObject(seaAdvantageObjectArray[0], 10, 25));
    }

    // level seviyesine gore spawn edilecek olan engeli belirler
    void SpawnDamageObject()
    {
        if (level <= 10)
        {
            RandomSeaDamageObjectGenerator(1);
        }
        else if (level <= 15)
        {
            RandomSeaDamageObjectGenerator(2);
        }
        else if (level <= 20)
        {
            RandomSeaDamageObjectGenerator(3);
        }
        else if (level > 20)
        {
            RandomSeaDamageObjectGenerator(4);
        }
    }

    // advantage ogesi spawn eder
    void SpawnAdvantageObject()
    {
        int possibility;
        possibility = Random.Range(0, 100);

        if (possibility < 20) // %20 olasilik ile 1 tane advantage ogesi spawn eder
        {
            RandomSeaAdvantageObjectGenerator(1);
        }
        
        else if (possibility < 35) // %35 olasilik ile 2 tane advantage ogesi spawn eder
        {
            RandomSeaAdvantageObjectGenerator(1);
            RandomSeaAdvantageObjectGenerator(1);
        }
    }

    //  x duzleminde random nokta uretir
    float RandomPositionXGenarator()
    {
        float positionX;

        positionX = Random.Range(-2.5f, 2.5f);

        //if (positionX < -0.5 && positionX > 0.5)
        //{
        //    if (Random.Range(1, 3) % 2 == 0)
        //    {
        //        positionX = Random.Range(-1f, 1f);
        //    }
        //}
        //else
        //{
        //    return positionX;
        //}

        return positionX;
    }

    // randrom olarak engeller olusturur
    void RandomSeaDamageObjectGenerator(int lvl)
    {
        if (sharkCreate.getPlayBool())
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(seaDamageObject[Random.Range(0, lvl)].getSeaGameObject(), new Vector3(RandomPositionXGenarator(), 0.3f, damagePositionZ), Quaternion.identity);
                damagePositionZ += 4.8f;
                advantageFishPositionZ = damagePositionZ - 0.5f;
                advantageCoinPositionZ = damagePositionZ - 0.8f;
            }
        }

    }

    // random fish advantage objesi olusturur
    void RandomSeaAdvantageObjectGenerator(int fishCount)
    {
        if (sharkCreate.getPlayBool())
        {
            Instantiate(seaAdvantageObject[Random.Range(0, fishCount)].getSeaGameObject(), new Vector3(RandomPositionXGenarator(), 0.3f, advantageFishPositionZ), Quaternion.identity);
            advantageFishPositionZ += 1f;
        }

    }

    // coin advantage objesi olusturur
    void CoinCreate()
    {
        if (sharkCreate.getPlayBool())
        {
            GameObject coinObject;

            int count = Random.Range(3, 5);
            for (int i = 0; i < count; i++)
            {
                coinObject = Instantiate(coin, new Vector3(RandomPositionXGenarator(), 0.3f, advantageCoinPositionZ), Quaternion.identity);
                coinObject.transform.Rotate(5, 0, 0);
                advantageCoinPositionZ += 1f;
            }
        }
    }

    void PositionControlZ()
    {
        if (!sharkCreate.getPlayBool())
        {
            damagePositionZ = sharkCreate.getSharkPlayer().transform.position.z + 20f;
            advantageFishPositionZ = damagePositionZ;
            advantageCoinPositionZ = damagePositionZ;
        }
    }
}
