using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoneLimit : MonoBehaviour
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
