using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// engellerin adini-gucunu-engel seviyesini tutar
public class SeaDamageObject
{
    public GameObject seaGameObject;
    public float powerOfObject;
    public int levelRating;

    public SeaDamageObject(GameObject seaGameObject, float powerOfObject)
    {
        this.seaGameObject = seaGameObject;
        this.powerOfObject = powerOfObject;
    }

    // engel objesini return eder
    public GameObject getSeaGameObject()
    {
        return seaGameObject;
    }

    // engelin verdigi zarari return eder
    public float getPoweOfObject()
    {
        return powerOfObject;
    }

}
