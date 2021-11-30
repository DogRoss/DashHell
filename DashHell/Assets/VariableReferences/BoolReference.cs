using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoolReference : MonoBehaviour
{
    public bool UseLocal;
    public bool localVariable;
    public BoolVariable globalVariable;

    public bool Value
    {
        get
        {
            return (UseLocal) ? localVariable : globalVariable.Value;
        }
    }
}
