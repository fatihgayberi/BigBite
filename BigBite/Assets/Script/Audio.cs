using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource audioSrcOther;
    AudioSource audioSrcShark;

    SharkSwim sharkSwim;
    // [SerializeField] AudioClip gameOverClip;
    // [SerializeField] AudioClip manaClip;
    [SerializeField] AudioClip manaClip;
    [SerializeField] AudioClip respawnClip;
    [SerializeField] AudioClip gameOverClip;

    private void Start()
    {
        sharkSwim = FindObjectOfType<SharkSwim>();

        audioSrcShark = GetComponent<AudioSource>();

        RespawnAudio();
        GameOverAudio();
    }

    private void Update()
    {
        ManaAudio();
        GameOverAudio();
    }

    void OnTriggerEnter(Collider other)
    {
        audioSrcOther = other.transform.gameObject.GetComponent<AudioSource>();
        string name = other.transform.name;

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

    void ManaAudio()
    {
        if (sharkSwim.getMana() == 100)
        {
            audioSrcShark.clip = manaClip;
        }
    }

    void RespawnAudio()
    {
        audioSrcShark.clip = respawnClip;
        audioSrcShark.Play();
    }

    void GameOverAudio()
    {
        if (!sharkSwim.getGameOver())
        {
            audioSrcShark.clip = gameOverClip;
            audioSrcShark.Play();
        }
    }
}
