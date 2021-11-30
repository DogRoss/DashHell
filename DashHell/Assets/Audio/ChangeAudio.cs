using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeAudio : MonoBehaviour
{

    [SerializeField] AudioMixer audioMixer;
    //[SerializeField] AudioMixerGroup mainVolume;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider musicSlider;

    void OnEnable() //set slider value to value of mainVolue
    {
        float audioLevel; //temp holder for values;

        audioMixer.GetFloat("MasterVolume", out audioLevel);
        volumeSlider.value = audioLevel;

        audioMixer.GetFloat("MusicVolume", out audioLevel);
        sfxSlider.value = audioLevel;

        audioMixer.GetFloat("SFXVolume", out audioLevel);
        musicSlider.value = audioLevel;
    }

    // Update is called once per frame
    public void UpdateAudio(float newLevel)
    {
        audioMixer.SetFloat("MasterVolume", newLevel);
    }

    public void UpdateSFX(float newLevel)
    {
        audioMixer.SetFloat("SFXVolume", newLevel);
    }

    public void UpdateMusic(float newLevel)
    {
        audioMixer.SetFloat("MusicVolume", newLevel);
    }
}
