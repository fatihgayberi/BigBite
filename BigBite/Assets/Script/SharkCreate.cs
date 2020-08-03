using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkCreate : MonoBehaviour
{
    public GameObject[] sharkArray; // shark prefablarini tutar
    public List<Shark> shark = new List<Shark>(); // sharklarin ozelliklerini tutan list
    int coinCounter; // oyuncunun bir bolumdeki parasini saklar
    GameObject sharkPlayer;
    int sharkIndex;
    SharkSwim sharkSwim;

    public DataManager dataManager;

    void Start()
    {
        sharkIndex = 1;
        SharkAdd();
        CreatePlayer(sharkIndex);
    }

    void SharkAdd()
    {
        shark.Add(new Shark(sharkArray[0], 100f, 2f, 2f, 4f, 1));
        shark.Add(new Shark(sharkArray[1], 150f, 2.5f, 4f, 5f, 2));
        shark.Add(new Shark(sharkArray[2], 200f, 3f, 6f, 6f, 3));
        shark.Add(new Shark(sharkArray[3], 250f, 3.5f, 8f, 7f, 4));
        shark.Add(new Shark(sharkArray[4], 300f, 4f, 10f, 8f, 5));
    }

    // shark oluşturur
    void CreatePlayer(int sharkIndex)
    {
        sharkPlayer =  Instantiate(shark[sharkIndex].getSharkObject(), new Vector3(0, 0.5f, 0), Quaternion.Euler(new Vector3(-90, -90, 0)));
        transform.parent = sharkPlayer.transform;
    }

    // oluşturulan sharki  return eder
    public GameObject getSharkPlayer()
    {
        return sharkPlayer;
    }

    // secili sharkin canini return eder
    public float getSelectHealth()
    {
        return shark[sharkIndex].getHealth();
    }

    // secili sharkin hizini return eder
    public float getSelectSpeed()
    {
        return shark[sharkIndex].getSpeed();
    }

    // secili sharkin mana suresini return eder
    public float getSelectManaTime()
    {
        return shark[sharkIndex].getManaTime();
    }

    // secili sharkin mana gucunu return eder
    public float getSelectManaPower()
    {
        return shark[sharkIndex].getManaPower();
    }

    // secili sharkin seviyesini return eder
    public int getSelectLevel()
    {
        return shark[sharkIndex].getLevel();
    }

    // oyuncunun parasini return eder
    public int getCoinCounter()
    {
        return coinCounter;
    }

    // oyuncunun parasini set eder
    public void setCoinCounter(int coinCounter)
    {
        this.coinCounter += coinCounter;
    }

    public void CoinGameSave()
    {
        sharkSwim = FindObjectOfType<SharkSwim>();
        dataManager.Load();
        dataManager.data.totalCoin += coinCounter;
        dataManager.data.coinCounter = coinCounter;
        dataManager.data.fishCounter = sharkSwim.getFishCounter();
        dataManager.Save();
    }
}
