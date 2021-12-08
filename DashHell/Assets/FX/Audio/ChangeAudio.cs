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

    //public GameObject passOverObj;

    public DontDestroy dontDestroy;

    //public GameObject musicObj;

    void OnEnable() //set slider value to value of mainVolue
    {

        //dontDestroy = passOverObj.GetComponent<DontDestroy>();

        float audioLevel; //temp holder for values;

        audioMixer.GetFloat("MasterVolume", out audioLevel);
        volumeSlider.value = audioLevel;
        

        audioMixer.GetFloat("MusicVolume", out audioLevel);
        sfxSlider.value = audioLevel;
        
        //volumeSlider.value = audioLevel;

        audioMixer.GetFloat("SFXVolume", out audioLevel);
        musicSlider.value = audioLevel;

        //volumeSlider.value = audioLevel;

        //DontDestroyOnLoad(musicObj);
        //DontDestroyOnLoad(musicObj);

        dontDestroy.SetMasterVol(volumeSlider);
        dontDestroy.SetMusicVol(musicSlider);
        dontDestroy.SetSFXVol(sfxSlider);

    }

    // Update is called once per frame
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

    /*
    private AudioSource backgroundSound;
    private static GameObject sound;
    private float volumeValue = 1f;

    void Start()
    {
        backgroundSound = GetComponent<AudioSource>();

        DontDestroyOnLoad(this.gameObject);

        if(sound == null)
        {
            sound = gameObject;

        }
        else
        {
            Destroy(gameObject);
        }


    }

    void Update()
    {
        backgroundSound.volume = volumeValue;    
    }

    public void updateVolume(float volume)
    {
        volumeValue = volume;
    }

    public void updateMusic(float volume)
    {
        volumeValue = volume;
    }

    public void updateSFX(float volume)
    {
        volumeValue = volume;
    }
    */
}
