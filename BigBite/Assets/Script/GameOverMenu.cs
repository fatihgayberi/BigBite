﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    SharkSwim sharkSwim;
    SharkCreate sharkCreate;
    MenuControl menuControl;
    public DataManager dataManager;

    public Text coinSumTxt;

    public Button playBtn;
    public Button homeBtn;

    void Start()
    {
        sharkSwim = FindObjectOfType<SharkSwim>();
        sharkCreate = FindObjectOfType<SharkCreate>();
        menuControl = FindObjectOfType<MenuControl>();
        Sea.damagePositionZ = 1.5f;
        playBtn.onClick.AddListener(TaskOnTouchPlay);
        homeBtn.onClick.AddListener(TaskOnTouchkHome);
    }

    void Update()
    {
        CanvasOutput();
    }

    void CanvasOutput()
    {
        SumCoinOutput(sharkCreate.getCoinCounter());
    }

    void SumCoinOutput(int coin)
    {
        coinSumTxt.text = coin.ToString();
    }

    public void TaskOnTouchPlay()
    {
        sharkSwim.AnimPlay("Swim");
        sharkSwim.ResetSecond();
        sharkSwim.setGameFinish(false);
        sharkCreate.setPlayBool(true);
        menuControl.GamePlayMenu(true);
        FinishSave();
        menuControl.GameOverMenu(false);
        sharkSwim.ResetFishCounter();
        sharkCreate.ResetCoinCounter();
    }

    public void TaskOnTouchkHome()
    {
        sharkSwim.AnimPlay("Swim");
        sharkSwim.ResetSecond();
        sharkCreate.getPlayBool();
        sharkSwim.setGameFinish(false);
        menuControl.StartMenu(true);
        FinishSave();
        menuControl.GameOverMenu(false);
        sharkSwim.ResetFishCounter();
        sharkCreate.ResetCoinCounter();
    }

    void FinishSave()
    {
        dataManager.Load();
        dataManager.data.totalCoin += sharkCreate.getCoinCounter();
        dataManager.Save();
    }
}