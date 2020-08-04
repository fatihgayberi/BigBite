using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
    public GameObject finishMenu;
    public Text coinSum;
    public Text fishSum;
    public Button playBtn;
    public Button homeBtn;
    public DataManager dataManager;


    void Start()
    {
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
        dataManager.Load();
        FishOutput(dataManager.data.fishCounter);
        CoinOutput(dataManager.data.coinCounter);        
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
