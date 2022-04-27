using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

/// <summary>
/// handles sliding credits down
/// </summary>
public class MoveTextOverTime : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("creditsShowing", true);
        
    }
}
