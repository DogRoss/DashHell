using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IntReference : MonoBehaviour
{

    public bool UseLocal;
    public int localVariable;
    public IntVariable globalVariable;

    public int Value
    {
        get
        {
            return (UseLocal) ? localVariable : globalVariable.Value;
        }
    }
}
