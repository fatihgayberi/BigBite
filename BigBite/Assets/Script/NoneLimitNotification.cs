using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoneLimitNotification : MonoBehaviour
{
    public GameObject notification;
    public Button closeBtn;

    void Start()
    {
        closeBtn.onClick.AddListener(TaskOnTouchClose);
    }

    void TaskOnTouchClose()
    {
        notification.gameObject.SetActive(false);
    }
}
