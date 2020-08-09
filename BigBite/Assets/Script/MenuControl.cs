using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject gamePlayMenu;
    public GameObject finishMenu;
    public GameObject marketMenu;

    public void StartMenu(bool mode)
    {
        startMenu.gameObject.SetActive(mode);
    }
    public void GamePlayMenu(bool mode)
    {
        gamePlayMenu.gameObject.SetActive(mode);
    }

    public void FinishMenu(bool mode)
    {
        finishMenu.gameObject.SetActive(mode);
    }

    public void MarketMenu(bool mode)
    {
        marketMenu.gameObject.SetActive(mode);
    }
}
