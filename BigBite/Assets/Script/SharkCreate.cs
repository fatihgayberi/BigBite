using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkCreate : MonoBehaviour
{    
    SharkSwim sharkSwim;
    public GameObject[] sharkArray; // shark prefablarini tutar
    public List<Shark> shark = new List<Shark>(); // sharklarin ozelliklerini tutan list
    GameObject sharkPlayer; // kopekbaligini tutar
    int coinCounter; // oyuncunun bir bolumdeki parasini saklar
    int sharkIndex; // kopekbaliginin indexini tutar
    bool playBool; // oyunun baslamasini tutan bool 
    public DataManager dataManager; // oyunun verilerini saklar

    void Start()
    {
        playBool = false;
        sharkIndex = 4;
        SharkAdd();
        CreatePlayer(sharkIndex);
    }

    // kopekbaliklarini listeye ekler
    void SharkAdd()
    {
        shark.Add(new Shark(sharkArray[0], 100f, 6f, 2f, 4f, 1));
        shark.Add(new Shark(sharkArray[1], 150f, 6.5f, 4f, 5f, 2));
        shark.Add(new Shark(sharkArray[2], 200f, 6f, 6f, 6f, 3));
        shark.Add(new Shark(sharkArray[3], 250f, 6.5f, 8f, 7f, 4));
        shark.Add(new Shark(sharkArray[4], 300f, 6f, 10f, 8f, 5));
    }

    // shark oluşturur
    void CreatePlayer(int sharkIndex)
    {
        sharkPlayer =  Instantiate(shark[sharkIndex].getSharkObject(), new Vector3(0, 1f, 0), Quaternion.identity);
        transform.parent = sharkPlayer.transform;
    }

    // oluşturulan sharki  return eder
    public GameObject getSharkPlayer()
    {
        return sharkPlayer;
    }

    // kopekbaliginin indexini return eder
    public int getSharkIndex()
    {
        return sharkIndex;
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

    public void ResetCoinCounter()
    {
        coinCounter = 0;
    }

    // oyuncunun parasini set eder
    public void setCoinCounter(int coinCounter)
    {
        this.coinCounter += coinCounter;
    }

    // oyun içinde tutlan parayı save eder
    public void CoinGameSave()
    {
        sharkSwim = FindObjectOfType<SharkSwim>();
        dataManager.Load();
        dataManager.data.totalCoin += coinCounter;
        dataManager.data.coinCounter = coinCounter;
        dataManager.data.fishCounter = sharkSwim.getFishCounter();
        dataManager.Save();
    }

    // oyunun baslamasini tutan bool u return eder
    public bool getPlayBool()
    {
        return playBool;
    }

    // oyunun baslamasini tutan bool u set eder
    public bool setPlayBool(bool isPlay)
    {
        return playBool = isPlay;
    }
}
