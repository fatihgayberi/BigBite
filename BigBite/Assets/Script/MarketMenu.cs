using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MarketMenu : MonoBehaviour
{
    public Button backBtn;
    public Text totalCoin;

    // Start is called before the first frame update
    void Start()
    {
        backBtn.onClick.AddListener(TaskOnTouchBack);
        TotalCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnTouchBack()
    {
        SceneManager.LoadScene("StartScene");
    }

    void TotalCoin()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        this.totalCoin.text = data.totalCoin + " Coin";
    }
}
