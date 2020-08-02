using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int coinCounter;

    public PlayerData(SharkCreate sharkCreate)
    {
        coinCounter = sharkCreate.getCoinCounter();
    }
}
