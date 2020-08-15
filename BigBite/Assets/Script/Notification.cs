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
        closeBtn.onClick.AddListener(TaskOnTouchClose);
    }

    private void Update()
    {
        notificationOutput.text = marketMenu.getNotificationOutput();
    }

    void TaskOnTouchClose()
    {
        notification.gameObject.SetActive(false);
    }
}
