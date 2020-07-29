using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    Sea seaClassObject;
    SharkCreate sharkCreate;

    float health; // oyuncunun canini saklar
    float mana; // oyuncunun mana gucunu tutar
    public float speed; // oyuncunun hizini saklar
    float speedModifier; // ekranda kaydırma islemi hassasiyetini saglar
    float seaPositionZ; // sea prefabının ilerleyecek bi sekilde olusmasi icin Z duzleminin pozisyonunu saklar
    float seconds; // oyunun icindeki gecen zamani saklar
    float endedGameTimer; // oyunun ne zaman bietecegini saklar

    public GameObject[] sea; // sea prefablarını tutan array unity uzerinden duzenlenir
    public GameObject finish; // bitis prefabı unity uzerinden atamasi yapilir

    bool moveOn; // oyuna dokunmadan baslamasini engeller
    bool gameFinish; // oyunun bitisini saglar

    void Start()
    {
        health = 100;
        mana = 0;
        speed = 5f;
        speedModifier = 0.005f;
        seaPositionZ = 8.5f;
        seconds = 0;
        endedGameTimer = 30f;
        moveOn = false;
        gameFinish = false;
        seaClassObject = FindObjectOfType<Sea>();
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

    // yeni bir sea olusturur
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Back") && seconds <= endedGameTimer)
        {
            GameObject seaObject = sea[Random.Range(0, sea.Length)];
            Instantiate(seaObject, new Vector3(0, 0, seaPositionZ), Quaternion.identity);
            seaPositionZ += 6;
        }

        for (int i = 0; i < seaClassObject.seaObject.Count; i++)
        {
            if (other.transform.name.Contains(seaClassObject.seaObject[i].getSeaGameObject().name))
            {
                health -= seaClassObject.seaObject[i].getPoweOfObject();
                break;
            }
        }
        Debug.Log("health: " + health);
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
