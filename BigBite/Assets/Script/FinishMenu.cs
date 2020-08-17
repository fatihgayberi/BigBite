using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
    AudioSource audioSrc;
    [SerializeField] AudioClip finishClip;

    public DataManager dataManager;

    public Text coinSumTxt;
    public Text fishSumTxt;
    public Text fishPrizeTxt;
    public Text barrelCoinTxt;
    public Text totalCoinTxt;

    public Button playBtn;
    public Button homeBtn;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public Sprite starInActive;
    public Sprite starActive;

    public GameObject[] sharkArray;
    public GameObject seaArea;

    int totalCoin;

    void Start()
    {
        audioSrc = seaArea.GetComponent<AudioSource>();
        FinishAudio();
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
        BarrielCoinOutput();
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

    void BarrielCoinOutput()
    {
        totalCoin += PlayerPrefs.GetInt("CoinBarrel");
        barrelCoinTxt.text = PlayerPrefs.GetInt("CoinBarrel") + "";
    }

    void TotalCoinOutput(int totalCoin)
    {
        totalCoinTxt.text = totalCoin + "";
    }

    public void TaskOnTouchPlay()
    {
        FinishSave();
        SceneManager.LoadScene("GameScene");
    }

    public void TaskOnTouchkHome()
    {
        FinishSave();
        SceneManager.LoadScene("GameScene");
    }

    public void UpdateStar()
    {
        totalCoin = PlayerPrefs.GetInt("Coin");//sharkCreate.getCoinCounter();
        if (PlayerPrefs.GetInt("fish") >= 3)
        {
            star1.gameObject.GetComponent<Image>().sprite = starActive;
            totalCoin += 25;
        }        
        if (PlayerPrefs.GetInt("fish") >= 5)
        {
            star2.gameObject.GetComponent<Image>().sprite = starActive;
            totalCoin += 35;
        }
        if (PlayerPrefs.GetInt("fish") >= 10)
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
                Instantiate(sharkArray[sharkIndex], new Vector3(0f, 3.5f, 0f), Quaternion.Euler(0, -90, 10));
                break;
            case 1:
                Instantiate(sharkArray[sharkIndex], new Vector3(-1f, 3.5f, 0f), Quaternion.Euler(0, -90, 10));
                break;
            case 2:
                Instantiate(sharkArray[sharkIndex], new Vector3(-0.5f, 3.7f, 0f), Quaternion.Euler(0, -90, 0));
                break;
            case 3:
                Instantiate(sharkArray[sharkIndex], new Vector3(0f, 3.7f, -0.5f), Quaternion.Euler(0, -90, 0));
                break;
            case 4:
                Instantiate(sharkArray[sharkIndex], new Vector3(0f, 3.7f, -0.5f), Quaternion.Euler(0, -90, 0));
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

    void FinishAudio()
    {
        if (PlayerPrefs.GetInt("Voice") != 0)
        {
            audioSrc.clip = finishClip;
            audioSrc.Play();
        }
    }
}
