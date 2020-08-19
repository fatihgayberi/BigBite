using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
    AudioSource audioSrc;
    Animation anim;
    public AudioClip finishClip;

    public DataManager dataManager;

    public Text coinSumTxt;
    public Text fishSumTxt;
    public Text fishPrizeTxt;
    public Text barrelCoinTxt;
    public Text totalCoinTxt;
    public Text totalScoreTxt;

    public Button playBtn;
    public Button homeBtn;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public Sprite starInActive;
    public Sprite starActive;

    public GameObject[] sharkArray;
    public GameObject seaArea;
    public GameObject highScoreParticle;
    public GameObject highScoreAlert;
    GameObject screenShark;


    int totalCoin;

    void Start()
    {
        audioSrc = seaArea.GetComponent<AudioSource>();
        SelectedShark();
        FinishAudio();
        HighScoreSave();
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
        TotalScoreOutput();
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

    void TotalScoreOutput()
    {
        totalScoreTxt.text = PlayerPrefs.GetInt("GameScore").ToString();
    }

    public void TaskOnTouchPlay()
    {
        PlayerPrefs.SetInt("Start", 1);
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
        totalCoin = PlayerPrefs.GetInt("Coin");
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
                screenShark = Instantiate(sharkArray[sharkIndex], new Vector3(0f, 3.5f, 0f), Quaternion.Euler(0, -90, 10));
                break;
            case 1:
                screenShark = Instantiate(sharkArray[sharkIndex], new Vector3(-1f, 3.5f, 0f), Quaternion.Euler(0, -90, 10));
                break;
            case 2:
                screenShark = Instantiate(sharkArray[sharkIndex], new Vector3(-0.5f, 3.7f, 0f), Quaternion.Euler(0, -90, 0));
                break;
            case 3:
                screenShark = Instantiate(sharkArray[sharkIndex], new Vector3(0f, 3.7f, -0.5f), Quaternion.Euler(0, -90, 0));
                break;
            case 4:
                screenShark = Instantiate(sharkArray[sharkIndex], new Vector3(0f, 3.7f, -0.5f), Quaternion.Euler(0, -90, 0));
                break;
            default:
                break;
        }
        AnimPlay(screenShark);
    }

    void FinishSave()
    {
        dataManager.Load();
        dataManager.data.totalCoin += totalCoin;
        dataManager.Save();
    }

    void HighScoreSave()
    {
        dataManager.Load();
        if (PlayerPrefs.GetInt("GameScore") > dataManager.data.HighScore)
        {
            dataManager.data.HighScore = PlayerPrefs.GetInt("GameScore");
            dataManager.Save();
            Instantiate(highScoreParticle, screenShark.transform.position, Quaternion.identity);
            highScoreAlert.SetActive(true);
        }
    }

    void FinishAudio()
    {
        if (PlayerPrefs.GetInt("Voice") != 0)
        {
            audioSrc.clip = finishClip;
            audioSrc.Play();
        }
    }

    void AnimPlay(GameObject finishShark)
    {
        anim = finishShark.transform.GetChild(0).gameObject.GetComponent<Animation>();
        anim.Play("Finish");
    }
}
