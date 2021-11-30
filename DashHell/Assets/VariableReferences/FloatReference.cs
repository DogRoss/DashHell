using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloatReference
{

    public bool UseLocal;
    public float localVariable;
    public FloatVariable globalVariable;

    public float Value
    {
        get
        {
            return (UseLocal) ? localVariable : globalVariable.Value; 
        }
    }
}
