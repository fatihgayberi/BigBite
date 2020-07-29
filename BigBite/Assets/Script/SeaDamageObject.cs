using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// engellerin adini-gucunu-engel seviyesini tutar
public class SeaDamageObject
{
    public GameObject seaGameObject;
    public float powerOfObject;
    public int levelRating;

    public SeaDamageObject(GameObject seaGameObject, float powerOfObject, int levelRating)
    {
        this.seaGameObject = seaGameObject;
        this.powerOfObject = powerOfObject;
        this.levelRating = levelRating;
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

    // engel seviyesini return eder
    public int getLevelRating()
    {
        return levelRating;
    }
}
