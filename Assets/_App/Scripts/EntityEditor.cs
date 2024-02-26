using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Entity))]
public class EntityEditor : Editor
{
    private Entity _entity;

    private SerializedProperty _settings;
    private SerializedProperty _behaviourType;

    private void OnEnable()
    {
        _entity = (Entity)target;
        _settings = serializedObject.FindProperty("_settings");
        _behaviourType = serializedObject.FindProperty("_behaviourType");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        bool visible = false;
        
        EditorGUILayout.PropertyField(_behaviourType);

        if (TransformBehaviourExtension.GetFlags(_entity.BehaviourType).Count() > 0)
            visible = true;

        if (visible)
            EditorGUILayout.PropertyField(_settings);

        serializedObject.ApplyModifiedProperties();
    }
}
