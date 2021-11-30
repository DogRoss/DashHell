using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    //

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        //base.OnInspectorGUI();
        GameEvent myGameEvent = (GameEvent)target;

        if (GUILayout.Button("Announce"))
        {
            myGameEvent.Announce();
        }
    }

    //
}
