using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject gamePlayMenu;

    public Text coinCounter;
    public Text fishCounter;

    public void StartMenu(bool mode)
    {
        startMenu.gameObject.SetActive(mode);
    }
    public void GamePlayMenu(bool mode)
    {
        gamePlayMenu.gameObject.SetActive(mode);
    }
}
