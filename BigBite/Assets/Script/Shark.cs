using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    float health;
    float mana;
    public float speed;
    float speedModifier;
    float seaPositionZ;
    float seconds;
    float endedGameTimer;
    int sharkIndex;

    public GameObject[] sea;
    public GameObject[] shark;
    private GameObject playerShark;
    public GameObject finish;

    bool moveOn;
    bool gameFinish;

    void Start()
    {
        sharkIndex = 3;
        health = 100;
        mana = 0;
        speed = 5f;
        speedModifier = 0.005f;
        seaPositionZ = 8.5f;
        seconds = 0;
        endedGameTimer = 5f;
        moveOn = false;
        gameFinish = false;
        CreatePlayer(3);
        //playerShark = shark[sharkIndex];
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

    void CreatePlayer(int sharkIndex)
    {
        playerShark = Instantiate(shark[sharkIndex], new Vector3(0, 0.5f, 0), Quaternion.identity);//playerShark.transform.rotation * Quaternion.Euler(-90, -90, 0));//new rota //Quaternion(-90, -90, 0));
    }
    public GameObject getShark()
    {
        return playerShark;
    }
    public float getHealth()
    {
        return health;
    }
    public float setHealth(float health)
    {
        return this.health = health;
         
    }
    public float getMana()
    {
        return mana;
    }
    public float setMana(float mana)
    {
        return this.mana = mana;
    }
    public float getSpeed()
    {
        return speed;
    }
    public float setSpeed(float speed)
    {
        return this.speed = speed;
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
            playerShark.transform.position = new Vector3(playerShark.transform.position.x, playerShark.transform.position.y, playerShark.transform.position.z + speed * Time.deltaTime);
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
