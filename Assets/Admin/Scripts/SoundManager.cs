using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] AudioSource soundButton;
    [SerializeField] AudioSource soundFall;
    [SerializeField] AudioSource soundFlap;
    [SerializeField] AudioSource soundHit;
    [SerializeField] AudioSource soundJingle;
    [SerializeField] AudioSource soundScore;

    [SerializeField] AudioClip audioButton;
    [SerializeField] AudioClip audioJingle;
    [SerializeField] AudioClip audioFall;
    [SerializeField] AudioClip audioFlap;
    [SerializeField] AudioClip audioHit;
    [SerializeField] AudioClip audioScore;

    public void SoundScore()
    {
        soundScore.PlayOneShot(audioScore);
    }
    public void SoundButton()
    {
        soundButton.PlayOneShot(audioButton);
    }
    public void SoundJingle()
    {
        soundJingle.PlayOneShot(audioJingle);
    }

    public void SoundFlap()
    {
        soundFlap.PlayOneShot(audioFlap);
    }
    public void SoundFall()
    {
        soundFall.PlayOneShot(audioFall);
    }
    public void SoundHit()
    {
        soundHit.PlayOneShot(audioHit);
    }

}
