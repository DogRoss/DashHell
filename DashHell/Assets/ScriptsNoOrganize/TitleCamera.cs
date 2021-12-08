using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCamera : MonoBehaviour
{
    public Animator anim;
    
    public void BeginSequence()
    {
        anim.SetBool("ClickedStart", true);
    }
}
