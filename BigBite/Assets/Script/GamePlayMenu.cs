using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayMenu : MonoBehaviour
{
    SharkSwim sharkSwim;
    SharkCreate SharkCreate;
    HealthBar healthBar;

    public Text coinCounter;
    public Text fishCounter;
    public Text totalScoreOutput;

    public GameObject[] combatImg;

    public Button pauseBtn;

    public GameObject pausePanel;

    int totalScore = 0;
    int combatFishCounter = 0;

    bool combatController = false;

    public Sprite killer;
    public Sprite hunter;
    public Sprite dread;

    private void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
        sharkSwim = FindObjectOfType<SharkSwim>();
        pauseBtn.onClick.AddListener(TaskOnTouchPause);
        healthBar.SetMaxHealth(sharkSwim.getHealth());
    }
    private void Update()
    {
        OutputCoinAndFish();
        healthBar.SetHealth(sharkSwim.getHealth());
        ScoreOutput();
        CombatSystem();
        StartCoroutine(CombatImageRemove());
    }

    // sayaclari output eder
    void OutputCoinAndFish()
    {
        sharkSwim = FindObjectOfType<SharkSwim>();
        SharkCreate = FindObjectOfType<SharkCreate>();

        fishCounter.text = sharkSwim.getFishCounter() + " Fish";
        coinCounter.text = SharkCreate.getCoinCounter() + " Coin";
    }

    // pause panelini active eder
    void TaskOnTouchPause()
    {
        Time.timeScale = 0;
        pausePanel.gameObject.SetActive(true);
    }

    void CombatSystem()
    {
        if (combatFishCounter > 0 && combatController)
        {
            combatController = false;
            int randomIndex;

            while (combatImg[randomIndex = Random.Range(0, combatImg.Length)].gameObject.GetComponent<Image>().sprite == null)
            {
                combatImg[randomIndex].SetActive(true);
                if (combatFishCounter < 3)
                {
                    combatImg[randomIndex].gameObject.GetComponent<Image>().sprite = killer;
                    break;
                }
                else if (3 <= combatFishCounter && combatFishCounter < 5)
                {
                    combatImg[randomIndex].gameObject.GetComponent<Image>().sprite = hunter;
                    break;
                }
                else if(combatFishCounter >= 5)
                {
                    combatImg[randomIndex].gameObject.GetComponent<Image>().sprite = dread;
                    break;
                }
            }
        }
    }

    IEnumerator CombatImageRemove()
    {
        for (int i = 0; i < combatImg.Length; i++)
        {
            if (combatImg[i].gameObject.GetComponent<Image>().sprite != null)
            {
                yield return new WaitForSeconds(0.5f);
                combatImg[i].gameObject.SetActive(false);
                combatImg[i].gameObject.GetComponent<Image>().sprite = null;
            }
        }
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

    public void CombatFishCounterPlus()
    {
        combatFishCounter++;
        combatController = true;
    }

    public void ResetCombatFishCounterPlus()
    {
        combatFishCounter = 0;
    }
}
