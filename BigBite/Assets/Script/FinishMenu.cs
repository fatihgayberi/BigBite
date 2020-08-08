using System.Collections;
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

    public GameObject star;

    public Sprite starInActive;
    public Sprite starActive;



    void Start()
    {
        Sea.damagePositionZ = 1.5f;
        playBtn.onClick.AddListener(TaskOnTouchPlay);
        homeBtn.onClick.AddListener(TaskOnTouchkHome);
        UpdateStar();
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

    IEnumerator CoinOutput(int coin)
    {
        for (int i = 1; i <= coin; i++)
        {
            coinSum.text = i.ToString() + " Altin";
            yield return new WaitForSeconds(1);
        }
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

    public void UpdateStar()
    {
        star.gameObject.GetComponent<Image>().sprite = starActive;
    }
}
