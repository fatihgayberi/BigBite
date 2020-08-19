using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sea : MonoBehaviour
{
    SharkCreate sharkCreate;
    SharkSwim sharkSwim;

    public GameObject[] seaDamageObjectArray; // unity uzerinden engeller eklenir
    public GameObject[] seaAdvantageObjectArray; // unity uzerinden engeller eklenir
    public List<SeaDamageObject> seaDamageObject = new List<SeaDamageObject>(); // engellerin ozelliklerini tutan list
    public List<SeaAdvantageObject> seaAdvantageObject = new List<SeaAdvantageObject>(); // engellerin ozelliklerini tutan list
    public GameObject coin; // oyundaki altini tutar unity uzerinden eklenir
    public GameObject barrel;
    public GameObject health;

    public static float damagePositionZ; // engellerin ilerleyecek bi sekilde olusmasi icin z duzleminin pozisyonunu tutar
    static float advantageFishPositionZ; // advantage objelerinin ilerleyecek bi sekilde olusmasi icin z duzleminin pozisyonunu tutar
    static float advantageCoinPositionZ;

    void Start()
    {
        sharkCreate = FindObjectOfType<SharkCreate>();
        sharkSwim = FindObjectOfType<SharkSwim>();
        LevelAddOject();
        RandomSeaDamageObjectGenerator(seaDamageObject.Count);
        SpawnAdvantageObject();
        RandomBarrelGenerator();
        CoinCreate();
        HealthCreate();
    }

    private void Update()
    {
        PositionControlZ();
    }

    // engelleri list e ekler
    void LevelAddOject()
    {
        // damage ogelerini ekler
        seaDamageObject.Add(new SeaDamageObject(seaDamageObjectArray[0], 15)); // 0-10 bölüm arası basit bölümlerden oluşacak
        seaDamageObject.Add(new SeaDamageObject(seaDamageObjectArray[1], 20)); // 10 - 15 bölüm arası kutular dahil edilecek
        seaDamageObject.Add(new SeaDamageObject(seaDamageObjectArray[2], 25)); // 15 - 20 bölüm arası mayın dahil edilecek
        seaDamageObject.Add(new SeaDamageObject(seaDamageObjectArray[3], 30)); // 20 -… bölümlerde radyo aktif kutular dahil edilecek ve hepsi karışık gelmeye başlayacak
        seaDamageObject.Add(new SeaDamageObject(seaDamageObjectArray[4], 35)); // 20 -… bölümlerde radyo aktif kutular dahil edilecek ve hepsi karışık gelmeye başlayacak
        seaDamageObject.Add(new SeaDamageObject(seaDamageObjectArray[5], 40)); // 20 -… bölümlerde radyo aktif kutular dahil edilecek ve hepsi karışık gelmeye başlayacak

        // advantage ogelerini ekler
        seaAdvantageObject.Add(new SeaAdvantageObject(seaAdvantageObjectArray[0], 10, 25));
        seaAdvantageObject.Add(new SeaAdvantageObject(seaAdvantageObjectArray[1], 10, 25));
        seaAdvantageObject.Add(new SeaAdvantageObject(seaAdvantageObjectArray[2], 15, 30));
        seaAdvantageObject.Add(new SeaAdvantageObject(seaAdvantageObjectArray[3], 15, 30));
    }

    // advantage ogesi spawn eder
    void SpawnAdvantageObject()
    {
        int possibility;
        possibility = Random.Range(0, 100);
        
        if (possibility < 35) // %35 olasilik ile 1 tane advantage ogesi spawn eder
        {
            RandomSeaAdvantageObjectGenerator();
        }
    }

    //  x duzleminde random nokta uretir
    float RandomPositionXGenarator()
    {
        return Random.Range(-2.5f, 2.5f);
    }

    // randrom olarak engeller olusturur
    void RandomSeaDamageObjectGenerator(int lvl)
    {
        GameObject barrier;

        if (sharkCreate.getPlayBool())
        {
            for (int i = 0; i < 3; i++)
            {
                barrier = Instantiate(seaDamageObject[Random.Range(0, lvl)].getSeaGameObject(), new Vector3(RandomPositionXGenarator(), 0.3f, damagePositionZ), Quaternion.identity);
                sharkSwim.allObject.Add(barrier);
                damagePositionZ += 4.8f;
                advantageFishPositionZ = damagePositionZ - 0.5f;
                advantageCoinPositionZ = damagePositionZ - 0.8f;
            }
        }
    }

    void RandomBarrelGenerator()
    {
        if (sharkCreate.getPlayBool())
        {
            GameObject brl;
            int possibility = Random.Range(0, 100);

            if (possibility <= 10)
            {
                brl = Instantiate(barrel, new Vector3(RandomPositionXGenarator(), 0.3f, damagePositionZ), Quaternion.identity);
                sharkSwim.allObject.Add(brl);
                damagePositionZ += 4.8f;
                advantageFishPositionZ = damagePositionZ - 0.5f;
                advantageCoinPositionZ = damagePositionZ - 0.8f;
            }
        }

    }

    // random fish advantage objesi olusturur
    void RandomSeaAdvantageObjectGenerator()
    {
        GameObject fish;

        if (sharkCreate.getPlayBool())
        {
            int fishCount = seaAdvantageObjectArray.Length;
            fish = Instantiate(seaAdvantageObject[Random.Range(0, fishCount)].getSeaGameObject(), new Vector3(RandomPositionXGenarator(), 0.3f, advantageFishPositionZ), Quaternion.identity);
            sharkSwim.allObject.Add(fish);
            advantageFishPositionZ += 1f;
        }

    }

    // coin advantage objesi olusturur
    void CoinCreate()
    {
        GameObject coinObject;
        if (sharkCreate.getPlayBool())
        {
            int count = Random.Range(3, 5);
            for (int i = 0; i < count; i++)
            {
                coinObject = Instantiate(coin, new Vector3(RandomPositionXGenarator(), 0.3f, advantageCoinPositionZ), Quaternion.identity);
                sharkSwim.allObject.Add(coinObject);
                advantageCoinPositionZ += 1f;
            }
        }
    }

    void HealthCreate()
    {
        int possibility = Random.Range(0, 100);

        if (possibility <= 10 && sharkCreate.getSelectHealth() * 0.75f >= sharkSwim.getHealth())
        {
            Instantiate(health, new Vector3(RandomPositionXGenarator(), 0.3f, damagePositionZ), Quaternion.identity);
        }        
    }

    void PositionControlZ()
    {
        if (sharkCreate.getPlayBool())
        {
            damagePositionZ = sharkSwim.getSeaPositionZ() - 3.5f;
            advantageFishPositionZ = damagePositionZ;
            advantageCoinPositionZ = damagePositionZ;
        }
    }
}
