using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark
{
    GameObject sharkObject;
    float sharkHP;
    float sharkSpeed;
    float sharkManaTime;
    float sharkManaPower;
    int sharkLevel;

    public Shark(GameObject sharkObject, float sharkHP, float sharkSpeed, float sharkManaTime, float sharkManaPower, int sharkLevel)
    {
        this.sharkObject = sharkObject;
        this.sharkHP = sharkHP;
        this.sharkSpeed = sharkSpeed;
        this.sharkManaTime = sharkManaTime;
        this.sharkManaPower = sharkManaPower;
        this.sharkLevel = sharkLevel;
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

    public float getLevel()
    {
        return sharkLevel;
    }
}
