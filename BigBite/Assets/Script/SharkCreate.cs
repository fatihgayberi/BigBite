using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkCreate : MonoBehaviour
{    
    public GameObject[] sharkArray; // shark prefablarini tutar
    public List<Shark> shark = new List<Shark>(); // sharklarin ozelliklerini tutan list
    GameObject sharkPlayer; // kopekbaligini tutar
    int coinCounter; // oyuncunun bir bolumdeki parasini saklar
    int barrelCoinCounter; // oyuncunun bir bolumdeki parasini saklar
    int sharkIndex; // kopekbaliginin indexini tutar
    bool playBool; // oyunun baslamasini tutan bool 
    public DataManager dataManager; // oyunun verilerini saklar

    void Start()
    {
        playBool = false;
        SelectShark();
        SharkAdd();
        CreatePlayer(sharkIndex);
    }

    // kopekbaliklarini listeye ekler
    void SharkAdd()
    {
        shark.Add(new Shark(sharkArray[0], 100f, SelectSharkSpeed(), SelectSharkPower(), 9.5f));
        shark.Add(new Shark(sharkArray[1], 150f, SelectSharkSpeed(), SelectSharkPower(), 10f));
        shark.Add(new Shark(sharkArray[2], 200f, SelectSharkSpeed(), SelectSharkPower(), 10.5f));
        shark.Add(new Shark(sharkArray[3], 250f, SelectSharkSpeed(), SelectSharkPower(), 11f));
        shark.Add(new Shark(sharkArray[4], 300f, SelectSharkSpeed(), SelectSharkPower(), 11.5f));
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

    // oyuncunun parasini return eder
    public int getCoinCounter()
    {
        return coinCounter;
    }

    // oyuncunun parasini 1 arttırır
    public void CoinCounterPlus()
    {
        coinCounter += 1;
        PlayerPrefs.SetInt("Coin", coinCounter);
    }

    public void BarrierCoinPlus()
    {
        barrelCoinCounter += 5;
        PlayerPrefs.SetInt("CoinBarrel", barrelCoinCounter);
    }

    // secilen kopekbaligini save dosyasından ceker
    void SelectShark()
    {
        dataManager.Load();
        sharkIndex = dataManager.data.selectedSharkIndex;
    }

    // secilen kopekbaliginin hizini save dosyasından ceker
    float SelectSharkSpeed()
    {
        dataManager.Load();
        int selectShark = dataManager.data.selectedSharkIndex;
        return dataManager.data.sharkSpeed[selectShark];
    }

    float SelectSharkPower()
    {
        dataManager.Load();
        int selectShark = dataManager.data.selectedSharkIndex;
        return dataManager.data.sharkPower[selectShark];
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
