using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] Sound[] tracks = null;
    [SerializeField] string startingTrack = null;

    private Sound currentTrack = null;

    void Awake()
    {
        foreach (Sound track in tracks)
        {
            track.source = gameObject.AddComponent<AudioSource>();
            track.source.clip = track.clip;
            track.source.pitch = track.pitch;
            track.source.loop = track.loop;
            track.source.volume = track.volume;
        }
    }

    private void Start()
    {
        Play(startingTrack);
    }

    public void Play(string trackName)
    {
        Sound track = Array.Find(tracks, trackClip => trackClip.name == trackName);

        if (track == null)
        {
            Debug.LogWarning("Sound: " + trackName + " not found.");
            return;
        }

        if (track.source == null)
        {
            return;
        }

        if (currentTrack != null && currentTrack.source.isPlaying)
        {
            if (currentTrack.source == track.source) { return; }
            currentTrack.source.Stop();
            track.source.Play();
            return;
        }

        track.source.Play();
        currentTrack = track;
    }

    private IEnumerator SwitchTrack(Sound nextTrack)
    {
        currentTrack.source.loop = false;
        yield return new WaitWhile(() => currentTrack.source.isPlaying);
        nextTrack.source.Play();
        nextTrack.source.loop = true;
        currentTrack = nextTrack;
    }

    public void SetMusicVolume(float value)
    {
        foreach (Sound track in tracks)
        {
            track.source.volume = track.volume * value;
        }
    }
}