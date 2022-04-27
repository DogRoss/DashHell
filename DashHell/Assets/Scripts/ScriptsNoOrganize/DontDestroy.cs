using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// handles all objects that transfer scene by scene
/// </summary>
public class DontDestroy : MonoBehaviour
{
    public static bool isCheatsOn = false;

    public float masterVol;
    public float musicVol;
    public float sfxVol;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// sets cheatState dependant on input
    /// </summary>
    public void SetBool(bool cheatState)
    {
        isCheatsOn = cheatState;
    }

    /// <summary>
    /// grabs cheat state
    /// </summary>
    public bool ReturnCheatState()
    {
        return isCheatsOn;
    }

    public void SetMasterVol(Slider slider)
    {
        masterVol = slider.value;
    }

    public void SetMusicVol(Slider slider)
    {
        musicVol = slider.value;
    }
    public void SetSFXVol(Slider slider)
    {
        sfxVol = slider.value;
    }


}
