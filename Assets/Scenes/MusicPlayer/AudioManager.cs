using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour
{

    public AudioClip[] MusicClips;
    private AudioSource Source;
    private int CurrentTrack;

    public Text clipTitleText;

    // Use this for initialization
    void Start()
    {
        Source = GetComponent<AudioSource>();

        //PLAY MUSIC
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (Source.isPlaying)
        {
            return;
        }
        CurrentTrack--;

        if (CurrentTrack < 0)
        {
            CurrentTrack = MusicClips.Length - 1;
        }
        StartCoroutine("WaitForMusicEnd");
    }

    IEnumerator WaitForMusicEnd()
    {
        while (Source.isPlaying)
        {
            yield return null;
        }
        NextTitle();
    }

    public void NextTitle()
    {
        Source.Stop();
        CurrentTrack++;
        if (CurrentTrack > MusicClips.Length - 1)
        {
            CurrentTrack = 0;
        }
        Source.clip = MusicClips[CurrentTrack];
        Source.Play();

        //show title
        ShowCurrentTitle();
        StartCoroutine("WaitForMusicEnd");

    }

    public void PreviousTitle()
    {
        Source.Stop();
        CurrentTrack--;
        if (CurrentTrack < 0)
        {
            CurrentTrack = MusicClips.Length - 1;
        }
        Source.clip = MusicClips[CurrentTrack];
        Source.Play();

        //show title
        ShowCurrentTitle();
        StartCoroutine("WaitForMusicEnd");
    }

    public void PauseMusic()
    {
        StopAllCoroutines();
        Source.Pause();
    }

    /*public void MuteMusic()
    {
        Source.mute = !Source.mute;
    }*/

    void ShowCurrentTitle()
    {
        clipTitleText.text = Source.clip.name;
    }

    void OnMouseUp()
    {
        PlayMusic();
    }
}
