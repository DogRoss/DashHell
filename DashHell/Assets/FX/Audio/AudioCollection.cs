using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollection : ScriptableObject
{


    public AudioClip[] clips;

    public AudioClip GetRandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }



}
