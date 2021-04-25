using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SettingsHolder : MonoBehaviour
{
    private float sfxVolume = 0.5f;
    private float musicVolume = 0.5f;


    private MusicPlayer musicPlayer;
    private AudioManager audioManager;

    public bool hasSwitchedMusic = false;

    private void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public float GetSFXVolume()
    {
        return sfxVolume;
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public void SetSFXVolume(float value)
    {
        sfxVolume = value;
        audioManager.SetSFXVolume(value);
    }

    public void SetMusicVolume(float value)
    {
        musicVolume = value;
        musicPlayer.SetMusicVolume(value);
    }
}