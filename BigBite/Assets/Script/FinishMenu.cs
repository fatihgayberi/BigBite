using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
    SharkSwim sharkSwim;
    SharkCreate sharkCreate;
    MenuControl menuControl;
    public DataManager dataManager;

    public Text coinSumTxt;
    public Text fishSumTxt;
    public Text fishPrizeTxt;
    public Text totalCoinTxt;

    public Button playBtn;
    public Button homeBtn;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public Sprite starInActive;
    public Sprite starActive;

    int totalCoin;

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
        UpdateStar();
        SumFishOutput(sharkSwim.getFishCounter());
        SumCoinOutput(sharkCreate.getCoinCounter());
        PrizeFishOutput();
        TotalCoinOutput(totalCoin);
    }

    void PrizeOutput()
    {
        PrizeFishOutput();
        TotalCoinOutput(totalCoin);
    }

    void SumCoinOutput(int coin)
    {
        coinSumTxt.text = coin.ToString();
    }

    void SumFishOutput(int fishCounter)
    {
        fishSumTxt.text = fishCounter.ToString();
    }

    void PrizeFishOutput()
    {
        int prize = totalCoin - sharkCreate.getCoinCounter();

        if (prize > 0)
        {
            fishPrizeTxt.text = prize.ToString();
        }
        else
        {
            fishPrizeTxt.text = "0";
        }
    }

    void TotalCoinOutput(int totalCoin)
    {
        totalCoinTxt.text = totalCoin.ToString();
    }

    public void TaskOnTouchPlay()
    {
        sharkSwim.AnimPlay("Swim");
        sharkSwim.ResetSecond();
        sharkSwim.setGameFinish(false);
        sharkCreate.setPlayBool(true);
        menuControl.GamePlayMenu(true);
        FinishSave();
        sharkSwim.ResetSpeed();
        menuControl.FinishMenu(false);
        sharkSwim.ResetFishCounter();
        sharkSwim.ResetBarrelPower();
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
        menuControl.FinishMenu(false);
        sharkSwim.ResetFishCounter();
        sharkSwim.ResetSpeed();
        sharkSwim.ResetBarrelPower();
        sharkCreate.ResetCoinCounter();
    }

    public void UpdateStar()
    {
        totalCoin = sharkCreate.getCoinCounter();
        if (sharkSwim.getFishCounter() >= 1)
        {
            star1.gameObject.GetComponent<Image>().sprite = starActive;
            totalCoin += 25;
        }        
        if (sharkSwim.getFishCounter() >= 15)
        {
            star2.gameObject.GetComponent<Image>().sprite = starActive;
            totalCoin += 35;
        }
        if (sharkSwim.getFishCounter() >= 20)
        {
            star3.gameObject.GetComponent<Image>().sprite = starActive;
            totalCoin += 45;
        }

    }

    void FinishSave()
    {
        dataManager.Load();
        dataManager.data.totalCoin += totalCoin;
        dataManager.Save();
    }

    IEnumerator AnimWait()
    {
        yield return new WaitForSeconds(2f);
        sharkSwim.AnimPlay("Swim");
    }
}
