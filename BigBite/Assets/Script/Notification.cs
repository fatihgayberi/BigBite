using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    MarketMenu marketMenu;
    public GameObject notification;
    public Button closeBtn;
    public Text notificationOutput;

    void Start()
    {
        marketMenu = FindObjectOfType<MarketMenu>();
        notificationOutput.text = marketMenu.getNotificationOutput();
        closeBtn.onClick.AddListener(TaskOnTouchClose);
    }

    void TaskOnTouchClose()
    {
        notification.gameObject.SetActive(false);
    }
}
