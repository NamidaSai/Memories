using UnityEngine;

public class ScreensaverHandler : MonoBehaviour
{
    private int _audioCycle = -1;

    private void Start()
    {
        OnAudio();
    }


    private void OnQuit()
    {
#if !UNITY_EDITOR
        Application.Quit();
#else
        Debug.Log("Application Quit");
#endif
    }

    private void OnAudio()
    {
        _audioCycle++;

        if (_audioCycle % 3 == 0)
        {
            FindObjectOfType<MusicPlayer>().SetMusicVolume(0f);
            FindObjectOfType<AudioManager>().SetSFXVolume(0f);
        }
        else if (_audioCycle % 3 == 1)
        {
            FindObjectOfType<AudioManager>().SetSFXVolume(1f);
            FindObjectOfType<MusicPlayer>().SetMusicVolume(0.05f);
        }
        else
        {
            FindObjectOfType<MusicPlayer>().SetMusicVolume(1f);
            FindObjectOfType<AudioManager>().SetSFXVolume(0.5f);
        }
    }
}