using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayMenu : MonoBehaviour
{
    public Text coinCounter;
    public Text fishCounter;

    SharkSwim sharkSwim;
    SharkCreate SharkCreate;

    private void Update()
    {
        OutputCoinAndFish();
    }

    // sayaclari output eder
    void OutputCoinAndFish()
    {
        sharkSwim = FindObjectOfType<SharkSwim>();
        SharkCreate = FindObjectOfType<SharkCreate>();

        fishCounter.text = sharkSwim.getFishCounter() + " BALIK";
        coinCounter.text = SharkCreate.getCoinCounter() + " ALTIN";
    }
}
