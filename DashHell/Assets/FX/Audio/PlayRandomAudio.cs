using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAudio : MonoBehaviour
{
    AudioCollection collection;
    AudioSource sourceAudio;

    private void Start()
    {

    }

    void PlaySound()
    {
        collection.GetRandomClip();
    }
}
