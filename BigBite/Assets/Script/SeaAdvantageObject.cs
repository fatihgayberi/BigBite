using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// mana ve can kazandiran objelerin adini-gucunu tutar
public class SeaAdvantageObject
{
    public GameObject seaGameObject;
    public float powerOfObjectHP;
    public float powerOfObjectMana;

    public SeaAdvantageObject(GameObject seaGameObject, float powerOfObjectHP, float powerOfObjectMana)
    {
        this.seaGameObject = seaGameObject;
        this.powerOfObjectHP = powerOfObjectHP;
        this.powerOfObjectMana = powerOfObjectMana;
    }

    // faydali objeyi return eder
    public GameObject getSeaGameObject()
    {
        return seaGameObject;
    }

    // faydali objenin kazandirdigi cani return eder
    public float getPowerOfObjectHP()
    {
        return powerOfObjectHP;
    }

    // faydali objenin kazandirdigi manayi return eder
    public float getPowerOfObjectMana()
    {
        return powerOfObjectMana;
    }
}
