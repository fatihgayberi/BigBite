using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// mana ve can kazandiran objelerin adini-gucunu tutar
public class SeaAdvantageObject
{
    public GameObject seaGameObject;
    public float powerOfObjectMana;

    public SeaAdvantageObject(GameObject seaGameObject, float powerOfObjectMana)
    {
        this.seaGameObject = seaGameObject;
        this.powerOfObjectMana = powerOfObjectMana;
    }

    // faydali objeyi return eder
    public GameObject getSeaGameObject()
    {
        return seaGameObject;
    }

    // faydali objenin kazandirdigi manayi return eder
    public float getPowerOfObjectMana()
    {
        return powerOfObjectMana;
    }
}
