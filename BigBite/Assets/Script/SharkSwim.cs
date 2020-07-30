using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkSwim : MonoBehaviour
{
    Sea sea;
    SharkCreate sharkCreate;

    float health; // oyuncunun canini saklar
    float mana; // oyuncunun mana gucunu tutar
    public float speed; // oyuncunun hizini saklar
    float speedModifier; // ekranda kaydırma islemi hassasiyetini saglar
    float seaPositionZ; // sea prefabının ilerleyecek bi sekilde olusmasi icin Z duzleminin pozisyonunu saklar
    float seconds; // oyunun icindeki gecen zamani saklar 
    float endedGameTimer; // oyunun ne zaman bietecegini saklar
    public GameObject[] seaPrefab; // sea prefablarını tutan array unity uzerinden duzenlenir
    public GameObject finish; // bitis prefabı unity uzerinden atamasi yapilir

    bool moveOn; // oyuna dokunmadan baslamasini engeller
    bool gameFinish; // oyunun bitisini saglar

    void Start()
    {        
        health = 100;
        mana = 30;
        speed = 5f;
        speedModifier = 0.005f;
        seaPositionZ = 2.5f;
        seconds = 0;
        endedGameTimer = 30f;
        moveOn = false;
        gameFinish = false;
        StartedSea();
        sea = FindObjectOfType<Sea>();
        sharkCreate = FindObjectOfType<SharkCreate>();        
    }

    void FixedUpdate()
    {
        MoveSpeed();
        Move();
    }

    private void Update()
    {
        GameFinish();
        SecondCounter();
    }

    // sag sol yapmasini saglar
    void Move()
    {
        if (Input.touchCount > 0)
        {
            moveOn = true;
            Touch touch;

            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y, transform.position.z);
            }
        }
    }

    // surekli olarak z ekseninde ilerlemesini saglar
    void MoveSpeed()
    {
        if (moveOn)
        {
            sharkCreate.getSharkPlayer().transform.position =  new Vector3(sharkCreate.getSharkPlayer().transform.position.x, sharkCreate.getSharkPlayer().transform.position.y, sharkCreate.getSharkPlayer().transform.position.z + speed * Time.deltaTime);
        }
    }

    // objelere degdiginde yapilmasi gereken islemleri yapar
    void OnTriggerEnter(Collider other)
    {
        BackColliderControl(other);

        DamageColliderControl(other);

        AdvantageColliderControl(other);

        Debug.Log("health: " + health + " mana: " + mana);
    }

    // kenarlara degdigi surece hızını dusurur
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Contains("Edge"))
        {
            speed = 1;
        }
    }

    // kenarlara degmeyi bitirdigini kontrol eder
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Contains("Edge"))
        {
            speed = 5;
        }
    }

    // baslangic icin bir sea prefabı baslatir
    void StartedSea()
    {
        GameObject seaObject = seaPrefab[Random.Range(0, seaPrefab.Length)];
        Instantiate(seaObject, new Vector3(0, 0, seaPositionZ), Quaternion.identity);
        seaPositionZ += 6;
    }

    // yeni bir sea olusturur
    void BackColliderControl(Collider collider)
    {
        if (collider.gameObject.name.Contains("Back") && seconds <= endedGameTimer)
        {
            GameObject seaObject = seaPrefab[Random.Range(0, seaPrefab.Length)];
            Instantiate(seaObject, new Vector3(0, 0, seaPositionZ), Quaternion.identity);
            seaPositionZ += 6;
        }
    }

    // damage objelerine degdiginde yapilmasi gerekenleri yapar
    void DamageColliderControl(Collider collider)
    {
        for (int i = 0; i < sea.seaDamageObject.Count; i++)
        {
            if (collider.transform.name.Contains(sea.seaDamageObject[i].getSeaGameObject().name))
            {
                health -= sea.seaDamageObject[i].getPoweOfObject();

                if (sharkCreate.get)
                {

                }
                break;
            }
        }
    }

    // advantage objelerine degdiginde yapilmasi gerekenleri yapar
    void AdvantageColliderControl(Collider collider)
    {
        for (int i = 0; i < sea.seaAdvantageObject.Count; i++)
        {
            if (collider.transform.name.Contains(sea.seaAdvantageObject[i].getSeaGameObject().name))
            {
                if (health + sea.seaAdvantageObject[i].getPoweOfObjectHP() > 100f)
                {
                    health = 100f;
                }
                
                if (health + sea.seaAdvantageObject[i].getPoweOfObjectHP() <= 100f)
                {
                    health += sea.seaAdvantageObject[i].getPoweOfObjectHP();
                }

                if (mana + sea.seaAdvantageObject[i].getPoweOfObjectMana() >= 100f)
                {
                    mana = 100f;
                    // mana 100 oldugunda fullenince patlama gerçekleşecek
                }

                if (mana + sea.seaAdvantageObject[i].getPoweOfObjectMana() < 100f)
                {
                    mana += sea.seaAdvantageObject[i].getPoweOfObjectMana();
                }

                break;
            }
        }
    }

    // oyunun suresini tutar
    void SecondCounter()
    {
        if (moveOn)
        {
            seconds += Time.deltaTime;
        }
    }

    // oyunu bitirir
    void GameFinish()
    {
        if (seconds > endedGameTimer && !gameFinish)
        {
            GameObject.Instantiate(finish, new Vector3(0, 0, seaPositionZ + 2), Quaternion.identity);
            gameFinish = true;
        }
    }

}
