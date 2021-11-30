using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEvent", menuName = "GameData/GameEvent")]
public class GameEvent : ScriptableObject
{
    List<GameEventListener> Listeners = new List<GameEventListener>();

    public void Register(GameEventListener go)
    {
        //add detection for if adding same object
        Listeners.Add(go);
    }

    public void DeRegister(GameEventListener go)
    {
        Listeners.Remove(go);
    }

    public void Announce()
    {
        foreach(GameEventListener listener in Listeners)
        {
            listener.AnnounceRelatedAction();
        }
    }
}
