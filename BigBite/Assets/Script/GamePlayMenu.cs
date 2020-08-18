using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayMenu : MonoBehaviour
{
    SharkSwim sharkSwim;
    SharkCreate SharkCreate;
    HealthBar healthBar;
    //ManaBar manaBar;

    public Text coinCounter;
    public Text fishCounter;
    public Text totalScoreOutput;

    public Button pauseBtn;

    public GameObject pausePanel;

    int totalScore = 0;


    private void Start()
    {
        //totalScore = 0;
        healthBar = FindObjectOfType<HealthBar>();
        //manaBar = FindObjectOfType<ManaBar>();
        sharkSwim = FindObjectOfType<SharkSwim>();
        pauseBtn.onClick.AddListener(TaskOnTouchPause);
        healthBar.SetMaxHealth(sharkSwim.getHealth());
        //manaBar.SetMaxMana(100f);
    }
    private void Update()
    {
        OutputCoinAndFish();
        healthBar.SetHealth(sharkSwim.getHealth());
        ScoreOutput();
        //manaBar.SetMana(sharkSwim.getMana());
    }

    // sayaclari output eder
    void OutputCoinAndFish()
    {
        sharkSwim = FindObjectOfType<SharkSwim>();
        SharkCreate = FindObjectOfType<SharkCreate>();

        fishCounter.text = sharkSwim.getFishCounter() + " BALIK";
        coinCounter.text = SharkCreate.getCoinCounter() + " ALTIN";
    }

    // pause panelini active eder
    void TaskOnTouchPause()
    {
        Time.timeScale = 0;
        pausePanel.gameObject.SetActive(true);
    }

    void ScoreOutput()
    {
        totalScoreOutput.text = totalScore + "";
    }

    public void setScorePlus(int score)
    {
        totalScore += score;
    }

    public int getScore()
    {
        return totalScore;
    }
}
