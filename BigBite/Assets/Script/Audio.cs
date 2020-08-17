using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource audioSrcOther;
    AudioSource audioSrcShark;

    SharkSwim sharkSwim;

    [SerializeField] AudioClip manaClip;
    [SerializeField] AudioClip respawnClip;

    private void Start()
    {
        sharkSwim = FindObjectOfType<SharkSwim>();

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
        }
    }

    //void ManaAudio()
    //{
    //    if (sharkSwim.getMana() == 100)// && PlayerPrefs.GetInt("Voice") == 0)
    //    {
    //
    //    }
    //}

    void RespawnAudio()
    {
        if (PlayerPrefs.GetInt("Voice") != 0)
        {
            audioSrcShark.clip = respawnClip;
            audioSrcShark.Play();
        }
    }
}
