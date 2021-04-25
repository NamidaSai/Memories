using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] const string MAIN_TRACK = default;
    [SerializeField] GameObject tutorialMenu = default;
    [SerializeField] GameObject optionsMenu = default;
    [SerializeField] Button playButton = default;
    [SerializeField] Slider sfxVolumeSlider = default;
    [SerializeField] Slider musicVolumeSlider = default;

    bool isOptionsMenu = false;

    SettingsHolder settings;

    private void Start()
    {
        settings = FindObjectOfType<SettingsHolder>();
        optionsMenu.SetActive(false);
        tutorialMenu.SetActive(true);
        AddListeners();
        ResetParameters();
    }

    private void AddListeners()
    {
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        playButton.onClick.AddListener(SwitchMusicTrack);
    }

    public void SwitchMusicTrack()
    {
        if (FindObjectOfType<SettingsHolder>().hasSwitchedMusic) { return; }

        FindObjectOfType<MusicPlayer>().Play(MAIN_TRACK);
        FindObjectOfType<SettingsHolder>().hasSwitchedMusic = true;
    }

    private void ResetParameters()
    {
        sfxVolumeSlider.value = settings.GetSFXVolume();
        musicVolumeSlider.value = settings.GetMusicVolume();
    }

    public void GoToOptionsMenu()
    {
        if (!isOptionsMenu)
        {
            tutorialMenu.SetActive(false);
            optionsMenu.SetActive(true);
            isOptionsMenu = true;
        }
        else
        {
            tutorialMenu.SetActive(true);
            optionsMenu.SetActive(false);
            isOptionsMenu = false;
        }
    }

    public void SetSFXVolume(float value)
    {
        settings.SetSFXVolume(value);
    }

    public void SetMusicVolume(float value)
    {
        settings.SetMusicVolume(value);
    }
}