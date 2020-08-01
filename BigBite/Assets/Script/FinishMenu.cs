using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
    public GameObject finishMenu;
    public Text coinSum;
    public Text fishSum;
    public Texture background;
    public GameObject star1Inactive;
    public GameObject star2Inactive;
    public GameObject star3Inactive;
    public Texture starActive;
    SharkSwim sharkSwim;
    SharkCreate sharkCreate;

    void Start()
    {
    }
    void Update()
    {
        EnableCanvas();
    }

    void EnableCanvas()
    {
        sharkSwim = FindObjectOfType<SharkSwim>();
        sharkCreate = FindObjectOfType<SharkCreate>();

        if (sharkSwim.getFinishMenu())
        {
            //BackGround();
            finishMenu.SetActive(true);
            StarUpdate(sharkSwim.getFishCounter());
            CoinOutput(sharkCreate.getCoinCounter());
            FishOutput(sharkSwim.getFishCounter());
        }
        else
        {
            finishMenu.SetActive(false);
        }
    }

    void CoinOutput(int coin)
    {
        coinSum.text = coin.ToString() + " Altin";
    }

    void FishOutput(int fishCounter)
    {
        fishSum.text = fishCounter.ToString() + " Balik";
    }

    void BackGround()
    {
        //GUI.DrawTexture(new Rect(0,0, 800, 600), background);
    }

    void StarUpdate(int fishCounter)
    {
        Debug.Log("line 60");
        if (fishCounter > -1)
        {
            Debug.Log("line 63");
            star1Inactive.GetComponent<Renderer>().material.mainTexture = starActive;
        }
    }
}
