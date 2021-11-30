using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringReference : MonoBehaviour
{
    public bool UseLocal;
    public string localVariable;
    public StringVariable globalVariable;

    public string Value
    {
        get
        {
            return (UseLocal) ? localVariable : globalVariable.Value;
        }
    }
}