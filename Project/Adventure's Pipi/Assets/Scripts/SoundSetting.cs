using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSetting : MonoBehaviour
{
    public Toggle soundToggle;

    void Start()
    {

        soundToggle.onValueChanged.AddListener(ToggleSound);
    }

    void ToggleSound(bool isSoundOn)
    {

        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();


        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.mute = !isSoundOn;
        }
    }
}

