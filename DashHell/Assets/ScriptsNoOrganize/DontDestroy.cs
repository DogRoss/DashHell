using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static bool isCheatsOn = false;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetBool(bool cheatState)
    {
        isCheatsOn = cheatState;
    }

    public bool ReturnCheatState()
    {
        return isCheatsOn;
    }
}
