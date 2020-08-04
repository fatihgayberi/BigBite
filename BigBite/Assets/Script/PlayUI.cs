using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    public Text coinCounter;
    public Text fishCounter;
    SharkSwim sharkSwim;
    SharkCreate SharkCreate;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OutputCoinAndFish();
    }

    void OutputCoinAndFish()
    {
        sharkSwim = FindObjectOfType<SharkSwim>();
        SharkCreate = FindObjectOfType<SharkCreate>();

        fishCounter.text = sharkSwim.getFishCounter() + " BALIK";
        coinCounter.text = SharkCreate.getCoinCounter() + " ALTIN";
    }
}
