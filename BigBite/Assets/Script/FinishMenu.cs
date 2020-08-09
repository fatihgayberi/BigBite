﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
    SharkSwim sharkSwim;
    SharkCreate sharkCreate;
    MenuControl menuControl;
    PlayUI playUI;

    public Text coinSum;
    public Text fishSum;

    public Button playBtn;
    public Button homeBtn;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public Sprite starInActive;
    public Sprite starActive;



    void Start()
    {
        sharkSwim = FindObjectOfType<SharkSwim>();
        sharkCreate = FindObjectOfType<SharkCreate>();
        menuControl = FindObjectOfType<MenuControl>();
        playUI = FindObjectOfType<PlayUI>();
        Sea.damagePositionZ = 1.5f;
        playBtn.onClick.AddListener(TaskOnTouchPlay);
        homeBtn.onClick.AddListener(TaskOnTouchkHome);
        UpdateStar();
    }

    void Update()
    {
        CanvasOutput();
    }

    void CanvasOutput()
    {
        FishOutput(sharkSwim.getFishCounter());
        CoinOutput(sharkCreate.getCoinCounter());        
    }

    void CoinOutput(int coin)
    {
        coinSum.text = coin + " Altin";
    }

    void FishOutput(int fishCounter)
    {
        fishSum.text = fishCounter.ToString() + " Balik";
    }

    public void TaskOnTouchPlay()
    {
        sharkSwim.ResetSecond();
        sharkSwim.setGameFinish(false);
        sharkCreate.setPlayBool(true);
        menuControl.GamePlayMenu(true);
        menuControl.FinishMenu(false);
        sharkSwim.ResetFishCounter();
        sharkCreate.ResetCoinCounter();
    }

    public void TaskOnTouchkHome()
    {
        sharkCreate.getPlayBool();
        sharkSwim.setGameFinish(false);
        sharkCreate.setPlayBool(true);
        menuControl.StartMenu(true);
        menuControl.ResetCounter();
        menuControl.FinishMenu(false);
        sharkSwim.ResetFishCounter();
        sharkCreate.ResetCoinCounter();
    }

    public void UpdateStar()
    {
        //star1.gameObject.GetComponent<Image>().sprite = starActive;
    }
}
