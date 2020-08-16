﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public Button voiceBtn;
    public Button vibrateBtn;
    public Button resumeBtn;

    public Sprite offVoice;
    public Sprite onVoice;
    public Sprite offVibrate;
    public Sprite onVibrate;

    // Start is called before the first frame update
    void Start()
    {
        voiceBtn.onClick.AddListener(TaskOnTouchVoice);
        vibrateBtn.onClick.AddListener(TaskOnTouchVibrate);
        resumeBtn.onClick.AddListener(TaskOnTouchResume);
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

    public void TaskOnTouchResume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}