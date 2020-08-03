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
        sharkSwim = FindObjectOfType<SharkSwim>();
        sharkCreate = FindObjectOfType<SharkCreate>();
        Sea.damagePositionZ = 1.5f;
        playBtn.onClick.AddListener(TaskOnTouchPlay);
        homeBtn.onClick.AddListener(TaskOnTouchkHome);
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
            FishOutput(sharkSwim.getFishCounter());
            CoinOutput(sharkCreate.getCoinCounter());
        }
        //else
        //{
        //    finishMenu.SetActive(false);
        //}
    }

    void CoinOutput(int coin)
    {
        coinSum.text = coin.ToString() + " Altin";
    }

    void FishOutput(int fishCounter)
    {
        fishSum.text = fishCounter.ToString() + " Balik";
    }

    public void TaskOnTouchPlay()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void TaskOnTouchkHome()
    {
        SceneManager.LoadScene("StartScene");
    }
}
