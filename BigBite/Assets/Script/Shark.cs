using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    float health = 100;
    float mana = 0;
    float speed = 5f;
    float screenWidth;
    Vector3 touchPosition;
    float speedModifier;
    bool moveOn = false;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        Debug.Log("width: " + screenWidth);

        speedModifier = 0.01f;
    }
    void Update()
    {
        MoveSpeed();
        Move();
    }

    float getHealth()
    {
        return health;
    }
    float setHealth(float health)
    {
        return this.health = health;
         
    }

    float getMana()
    {
        return mana;
    }
    float setMana(float mana)
    {
        return this.mana = mana;
    }

    float getSpeed()
    {
        return speed;
    }
    float setSpeed(float speed)
    {
        return this.speed = speed;
    }

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

    void MoveSpeed()
    {
        if (moveOn)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
        }
    }
}
