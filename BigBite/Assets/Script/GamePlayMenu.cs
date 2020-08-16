using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayMenu : MonoBehaviour
{
    SharkSwim sharkSwim;
    SharkCreate SharkCreate;
    HealthBar healthBar;
    ManaBar manaBar;

    public Text coinCounter;
    public Text fishCounter;

    public Button pauseBtn;

    public GameObject pausePanel;


    private void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
        manaBar = FindObjectOfType<ManaBar>();
        sharkSwim = FindObjectOfType<SharkSwim>();
        pauseBtn.onClick.AddListener(TaskOnTouchPause);
        healthBar.SetMaxHealth(sharkSwim.getHealth());
        manaBar.SetMaxMana(100f);
    }
    private void Update()
    {
        OutputCoinAndFish();
        healthBar.SetHealth(sharkSwim.getHealth());
        manaBar.SetMana(sharkSwim.getMana());
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
}
