using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource audioSrcOther;
    AudioSource audioSrcShark;

    public AudioClip manaClip;
    public AudioClip respawnClip;

    private void Start()
    {
        audioSrcShark = GetComponent<AudioSource>();

        RespawnAudio();
    }

    void OnTriggerEnter(Collider other)
    {
        audioSrcOther = other.transform.gameObject.GetComponent<AudioSource>();
        string name = other.transform.name;

        if (PlayerPrefs.GetInt("Voice") != 0)
        {
            if (name.Contains("Fish"))
            {
                audioSrcOther.Play();
            }
            if (name.Contains("Mine"))
            {
                audioSrcOther.Play();
            }
            if (name.Contains("Box"))
            {
                audioSrcOther.Play();
            }
            if (name.Contains("Anchor"))
            {
                audioSrcOther.Play();
            }
            if (name.Contains("Barrel"))
            {
                audioSrcOther.Play();
            }
            if (name.Contains("Coin"))
            {
                audioSrcOther.Play();
            }
            if (name.Contains("Shipwreck"))
            {
                audioSrcOther.Play();
            }
            if (name.Contains("Propeller"))
            {
                audioSrcOther.Play();
            }
            if (name.Contains("Wheel"))
            {
                audioSrcOther.Play();
            }
            if (name.Contains("Health"))
            {
                audioSrcOther.Play();
            }
        }
    }

    void RespawnAudio()
    {
        if (PlayerPrefs.GetInt("Voice") != 0)
        {
            audioSrcShark.clip = respawnClip;
            audioSrcShark.Play();
        }
    }
}
