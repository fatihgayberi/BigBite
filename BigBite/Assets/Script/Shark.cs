using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark
{
    GameObject sharkObject; // sharki tutar
    float sharkHP; // sharkin canini tutar
    float sharkSpeed; // sharkin hizini tutar
    float sharkManaTime; // sharkin manasi fullendiginde sharkManaTime kadar mana ozel guc calisir
    float sharkManaPower; // ozel guc calistiginda hizi sharkManaPower kadar olur

    public Shark(GameObject sharkObject, float sharkHP, float sharkSpeed, float sharkManaTime, float sharkManaPower)
    {
        this.sharkObject = sharkObject;
        this.sharkHP = sharkHP;
        this.sharkSpeed = sharkSpeed;
        this.sharkManaTime = sharkManaTime;
        this.sharkManaPower = sharkManaPower;
    }

    public GameObject getSharkObject()
    {
        return sharkObject;
    }

    public float getHealth()
    {
        return sharkHP;
    }

    public float getSpeed()
    {
        return sharkSpeed;
    }

    public float getManaTime()
    {
        return sharkManaTime;
    }

    public float getManaPower()
    {
        return sharkManaPower;
    }
}
