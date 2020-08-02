using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
    public GameObject finishMenu;
    public Text coinSum;
    public Text fishSum;
    SharkSwim sharkSwim;
    SharkCreate sharkCreate;

    public Button playBtn;
    public Button homeBtn;

    void Start()
    {
        Sea.damagePositionZ = 1.5f;
        sharkSwim = FindObjectOfType<SharkSwim>();
        sharkCreate = FindObjectOfType<SharkCreate>();

        homeBtn.onClick.AddListener(TaskOnClickHome);
        playBtn.onClick.AddListener(TaskOnClickPlay);

        CoinOutput(sharkCreate.getCoinCounter());
        FishOutput(sharkSwim.getFishCounter());
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
            finishMenu.SetActive(true);
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

    void TaskOnClickPlay()
    {
        SceneManager.LoadScene("GameScene");
    }

    void TaskOnClickHome()
    {
        SceneManager.LoadScene("StartScene");
    }
}
