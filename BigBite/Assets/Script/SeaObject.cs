using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class SeaObject
{
    public GameObject seaGameObject;
    public float powerOfObject;
    public int levelRating;

    public SeaObject(GameObject seaGameObject, float powerOfObject, int levelRating)
    {
        this.seaGameObject = seaGameObject;
        this.powerOfObject = powerOfObject;
        this.levelRating = levelRating;
    }

    public GameObject getSeaGameObject()
    {
        return seaGameObject;
    }
    public float getPoweOfObject()
    {
        return powerOfObject;
    }
    public int getLevelRating()
    {
        return levelRating;
    }
}
