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
    bool playBool;
    SharkSwim sharkSwim;
    Animator anim;

    public DataManager dataManager;

    void Start()
    {
        playBool = false;
        sharkIndex = 1;
        SharkAdd();
        CreatePlayer(sharkIndex);
    }

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
        //anim = sharkPlayer.GetComponent<Animator>();
        //anim.SetBool("Swim2", true);
    }

    // oluşturulan sharki  return eder
    public GameObject getSharkPlayer()
    {
        return sharkPlayer;
    }

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

    public bool getPlayBool()
    {
        return playBool;
    }

    public bool setPlayBool(bool isPlay)
    {
        return playBool = isPlay;
    }
}
