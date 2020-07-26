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

    public GameObject sea;
    public GameObject finish;

    bool moveOn;
    bool gameFinish;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        mana = 0;
        speed = 5f;
        speedModifier = 0.005f;
        seaPositionZ = 16;
        seconds = 0;
        endedGameTimer = 5f;
        moveOn = false;
        gameFinish = false;
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
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Back") && seconds <= endedGameTimer)
        {
            GameObject.Instantiate(sea, new Vector3(0, 0, seaPositionZ), Quaternion.identity);
            seaPositionZ += 6;
        }
    }    

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Contains("Edge"))
        {
            speed = 1;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Contains("Edge"))
        {
            speed = 5;
        }
    }

    void SecondCounter()
    {
        if (moveOn)
        {
            seconds += Time.deltaTime;
        }
    }

    void GameFinish()
    {
        if (seconds > endedGameTimer && !gameFinish)
        {
            GameObject.Instantiate(finish, new Vector3(0, 0, seaPositionZ), Quaternion.identity);
            gameFinish = true;
        }
    }
}
