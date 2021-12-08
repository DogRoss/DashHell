 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] GameEvent gameEvent;
    [SerializeField] UnityEvent thingToDo;

    // Start is called before the first frame update
    void OnEnable()
    {
        gameEvent.Register(this);
    }

    private void OnDisable()
    {
        gameEvent.DeRegister(this);        
    }

    public void AnnounceRelatedAction()
    {
        thingToDo.Invoke();
    }
}
