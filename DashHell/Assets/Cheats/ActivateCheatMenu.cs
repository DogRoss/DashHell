using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateCheatMenu : MonoBehaviour
{
    [SerializeField] char[] code = new char[4];
    [SerializeField] char[] entered = new char[4];

    [SerializeField] UnityEvent CheatActivatedEvent;

    void UpdateEntered(char c)
    {
        char[] temp = new char[4];
        temp[0] = c;
        for(int i = 1; i < entered.Length; i++)
        {
            temp[i] = entered[i - 1];
        }
        entered = temp;

        CompareCode();

    }

    void CompareCode()
    {
        for(int i = 0; i < code.Length; i++)
        {
            if(entered[i] != code[i])//if incorrect input //if doesnt match current code
            {
                return;
            }
            
            
        }
        Debug.Log("CheatActivated");
        CheatActivatedEvent.Invoke();

    }

    private void OnUp()
    {
        UpdateEntered('u');
    }

    private void OnDown()
    {
        UpdateEntered('d');
    }

    private void OnLeft()
    {
        UpdateEntered('l');
    }

    private void OnRight()
    {
        UpdateEntered('r');
    }
}
