﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MarketMenu : MonoBehaviour
{
    SharkCreate sharkCreate;
    public Button backBtn;
    public Text totalCoin;

    // Start is called before the first frame update
    void Start()
    {
        backBtn.onClick.AddListener(TaskOnTouchBack);
        sharkCreate = FindObjectOfType<SharkCreate>();
        TotalCoin(sharkCreate.totalCoin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnTouchBack()
    {
        SceneManager.LoadScene("StartScene");
    }

    void TotalCoin(int totalCoin)
    {
        this.totalCoin.text = totalCoin.ToString() + " Coin";
    }
}
