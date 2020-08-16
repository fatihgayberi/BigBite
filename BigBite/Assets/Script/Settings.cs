﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Button voiceBtn;
    public Button closeBtn;
    public Button vibrateBtn;

    public Sprite offVoice;
    public Sprite onVoice;
    public Sprite offVibrate;
    public Sprite onVibrate;

    // Start is called before the first frame update
    void Start()
    {
        voiceBtn.onClick.AddListener(TaskOnTouchVoice);
        vibrateBtn.onClick.AddListener(TaskOnTouchVibrate);
        closeBtn.onClick.AddListener(TaskOnTouchClose);
        VoiceStart();
        VibrateStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnTouchVoice()
    {
        VoiceIconChange();
    }

    void VoiceIconChange()
    {
        if (PlayerPrefs.GetInt("voice") == 0)
        {
            voiceBtn.image.sprite = onVoice;
            PlayerPrefs.SetInt("voice", 1);
        }
        else
        {
            voiceBtn.image.sprite = offVoice;
            PlayerPrefs.SetInt("voice", 0);
        }
    }

    void VoiceStart()
    {
        if (PlayerPrefs.GetInt("voice") == 0)
        {
            voiceBtn.image.sprite = offVoice;
        }
        else
        {
            voiceBtn.image.sprite = onVoice;
        }
    }

    void VibrateStart()
    {
        if (PlayerPrefs.GetInt("Vibrate") == 0)
        {
            vibrateBtn.image.sprite = offVibrate;
        }
        else
        {
            vibrateBtn.image.sprite = onVibrate;
        }
    }

    void TaskOnTouchVibrate()
    {
        if (PlayerPrefs.GetInt("Vibrate") == 0)
        {
            vibrateBtn.image.sprite = onVibrate;
            PlayerPrefs.SetInt("Vibrate", 1);
            Handheld.Vibrate();
        }
        else
        {
            vibrateBtn.image.sprite = offVibrate;
            PlayerPrefs.SetInt("Vibrate", 0);
        }
    }

    void TaskOnTouchClose()
    {
        gameObject.SetActive(false);
    }
}