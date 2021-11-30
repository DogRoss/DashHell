using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(FloatReference))]
public class FloatReferenceDrawer : PropertyDrawer
{
    //options for using local or global
    private readonly string[] popUpOptions = { "Use Local", "Use Global" };

    public GUIStyle popUpStyle;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);
        if (popUpStyle == null)
        {
            popUpStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
            popUpStyle.imagePosition = ImagePosition.ImageOnly;
        }

        label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, label);

        EditorGUI.BeginChangeCheck(); //where the editor checks if you have change...

        SerializedProperty useLocal = property.FindPropertyRelative("UseLocal");
        SerializedProperty localValue = property.FindPropertyRelative("localValue");
        SerializedProperty globalValue = property.FindPropertyRelative("globalValue");

        //calculate rect for button
        Rect buttonRect = new Rect(position);
        buttonRect.yMin += popUpStyle.margin.top;
        buttonRect.width = popUpStyle.fixedWidth + popUpStyle.margin.right;
        position.xMin = buttonRect.xMax;

        //store old indent value
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        int result = EditorGUI.Popup(buttonRect, useLocal.boolValue ? 0 : 1, popUpOptions, popUpStyle);

        useLocal.boolValue = result == 0;

        EditorGUI.PropertyField(position, 
            useLocal.boolValue ? localValue : globalValue, GUIContent.none);

        //apply any changes we made to the inspector to the values they represent
        if (EditorGUI.EndChangeCheck())
        {
            property.serializedObject.ApplyModifiedProperties();
        }

        //move the indent back
        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();

    }


}
