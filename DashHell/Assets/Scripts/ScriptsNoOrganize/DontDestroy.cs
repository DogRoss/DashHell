using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//handles all objects that transfer scene by scene
public class DontDestroy : MonoBehaviour
{
    public static bool isCheatsOn = false;
    //public static GameObject optionsMenu;

    public float masterVol;
    public float musicVol;
    public float sfxVol;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        //DontDestroyOnLoad(optionsMenu.gameObject);
    }

    //saves cheats
    public void SetBool(bool cheatState)
    {
        isCheatsOn = cheatState;
    }

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
