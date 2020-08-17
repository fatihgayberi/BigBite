using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmNotification : MonoBehaviour
{
    AudioSource audioSrc;

    public GameObject marketArea;

    public AudioClip buyClip;

    MarketMenu marketMenu;

    public DataManager dataManager;

    public Button confirmBtn;
    public Button closeBtn;

    public GameObject confirmPanel;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = marketArea.GetComponent<AudioSource>();
        marketMenu = FindObjectOfType<MarketMenu>();
        confirmBtn.onClick.AddListener(TaskOnTouchConfirm);
        closeBtn.onClick.AddListener(TaskOnTouchClose);
    }

    void TaskOnTouchConfirm()
    {
        ConfirmAudio();
        dataManager.Load();
        marketMenu.priceOutput.text = "Secili";
        dataManager.data.totalCoin -= dataManager.data.sharkPrice[marketMenu.sharkIndex];
        dataManager.data.buyingShark[marketMenu.sharkIndex] = true;
        dataManager.data.selectedSharkIndex = marketMenu.sharkIndex;
        marketMenu.totalCoin.text = dataManager.data.totalCoin + " ALTIN";
        marketMenu.specialPower.gameObject.SetActive(true);
        dataManager.Save();
        confirmPanel.gameObject.SetActive(false);
    }

    void TaskOnTouchClose()
    {
        confirmPanel.gameObject.SetActive(false);
    }

    void ConfirmAudio()
    {
        if (PlayerPrefs.GetInt("Voice") != 0)
        {
            audioSrc = marketArea.GetComponent<AudioSource>();
            audioSrc.clip = buyClip;
            audioSrc.Play();
        }
    }
}
