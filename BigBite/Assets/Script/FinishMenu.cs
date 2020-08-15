using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
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

    public GameObject[] sharkArray;

    int totalCoin;

    void Start()
    {
        playBtn.onClick.AddListener(TaskOnTouchPlay);
        homeBtn.onClick.AddListener(TaskOnTouchkHome);
        SelectedShark();
    }

    void Update()
    {
        CanvasOutput();
    }

    void CanvasOutput()
    {
        UpdateStar();
        SumFishOutput(PlayerPrefs.GetInt("fish"));
        SumCoinOutput(PlayerPrefs.GetInt("Coin"));
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
        int prize = totalCoin - PlayerPrefs.GetInt("Coin");

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
        //sharkSwim.AnimPlay("Swim");
        //sharkSwim.ResetSecond();
        //sharkSwim.setGameFinish(false);
        //sharkCreate.setPlayBool(true);
        //menuControl.GamePlayMenu(true);
        FinishSave();
        //PrefsReset();
        //sharkSwim.ResetSpeed();
        //menuControl.FinishMenu(false);
        //sharkSwim.ResetFishCounter();
        //sharkSwim.ResetBarrelPower();
        //sharkCreate.ResetCoinCounter();
        SceneManager.LoadScene("GameScene");
    }

    public void TaskOnTouchkHome()
    {
        //sharkSwim.AnimPlay("Swim");
        //sharkSwim.ResetSecond();
        //sharkCreate.getPlayBool();
        //sharkSwim.setGameFinish(false);
        //menuControl.StartMenu(true);
        FinishSave();
        //PrefsReset();
        //menuControl.FinishMenu(false);
        //sharkSwim.ResetFishCounter();
        //sharkSwim.ResetSpeed();
        //sharkSwim.ResetBarrelPower();
        //sharkCreate.ResetCoinCounter();
        SceneManager.LoadScene("GameScene");
    }

    public void UpdateStar()
    {
        totalCoin = PlayerPrefs.GetInt("Coin");//sharkCreate.getCoinCounter();
        if (PlayerPrefs.GetInt("fish") >= 1)
        {
            star1.gameObject.GetComponent<Image>().sprite = starActive;
            totalCoin += 25;
        }        
        if (PlayerPrefs.GetInt("fish") >= 15)
        {
            star2.gameObject.GetComponent<Image>().sprite = starActive;
            totalCoin += 35;
        }
        if (PlayerPrefs.GetInt("fish") >= 20)
        {
            star3.gameObject.GetComponent<Image>().sprite = starActive;
            totalCoin += 45;
        }

    }

    void SelectedShark()
    {
        dataManager.Load();
        int sharkIndex = dataManager.data.selectedSharkIndex;
        switch (sharkIndex)
        {
            case 0:
                Instantiate(sharkArray[sharkIndex], new Vector3(-2f, 3.5f, -0.1f), Quaternion.Euler(-5, 20, 20));
                break;
            case 1:
                Instantiate(sharkArray[sharkIndex], new Vector3(-2f, 3.5f, 0.8f), Quaternion.Euler(-5, 20, 20));
                break;
            case 2:
                Instantiate(sharkArray[sharkIndex], new Vector3(-2f, 3.5f, 0.3f), Quaternion.Euler(-5, 20, 20));
                break;
            case 3:
                Instantiate(sharkArray[sharkIndex], new Vector3(-2f, 3.5f, -0.2f), Quaternion.Euler(-5, 20, 20));
                break;
            case 4:
                Instantiate(sharkArray[sharkIndex], new Vector3(-3f, 3.2f, -0.3f), Quaternion.Euler(-5, 20, 20));
                break;
            default:
                break;
        }
    }

    void FinishSave()
    {
        dataManager.Load();
        dataManager.data.totalCoin += totalCoin;
        dataManager.Save();
    }
}
