using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// changes audio noise level dependant on input
/// </summary>
public class ChangeAudio : MonoBehaviour
{
    
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider musicSlider;

    public DontDestroy dontDestroy;

    void OnEnable() //set slider value to value of mainVolue
    {

        float audioLevel; //temp holder for values;

        //sets volumes to determined values
        audioMixer.GetFloat("MasterVolume", out audioLevel);
        volumeSlider.value = audioLevel;
        

        audioMixer.GetFloat("MusicVolume", out audioLevel);
        sfxSlider.value = audioLevel;

        audioMixer.GetFloat("SFXVolume", out audioLevel);
        musicSlider.value = audioLevel;

        dontDestroy.SetMasterVol(volumeSlider);
        dontDestroy.SetMusicVol(musicSlider);
        dontDestroy.SetSFXVol(sfxSlider);

    }

    public void UpdateAudio(float newLevel)
    {
        audioMixer.SetFloat("MasterVolume", newLevel);
        dontDestroy.SetMasterVol(volumeSlider);
    }

    public void UpdateSFX(float newLevel)
    {
        audioMixer.SetFloat("SFXVolume", newLevel);
        dontDestroy.SetSFXVol(sfxSlider);
    }

    public void UpdateMusic(float newLevel)
    {
        audioMixer.SetFloat("MusicVolume", newLevel);
        dontDestroy.SetMusicVol(musicSlider);
    }

    
}
