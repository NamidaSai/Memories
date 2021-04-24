using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;
using System.Reflection;
using System.Collections;

// source: https://forum.unity.com/threads/random-2d-shape-generation.376836/

[CustomEditor(typeof(SortingLayers3D))]
public class SortingLayers3DEditor : Editor
{

    string[] options = new string[] { };


    void OnEnable()
    {
        options = GetSortingLayerNames();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SortingLayers3D S = (SortingLayers3D)target;
        Transform T = (Transform)S.transform;


        EditorGUILayout.BeginHorizontal();
        S.index = EditorGUILayout.Popup("Sorting Layer", S.index, options, EditorStyles.popup);
        EditorGUILayout.EndHorizontal();

        S.order = EditorGUILayout.IntField("Order in Layer", S.order);

        //Debug.Log(T.renderer.sortingLayerName);
        T.GetComponent<Renderer>().sortingLayerName = options[S.index];
        T.GetComponent<Renderer>().sortingOrder = S.order;
    }


    // Get the sorting layer names
    public string[] GetSortingLayerNames()
    {
        Type internalEditorUtilityType = typeof(InternalEditorUtility);
        PropertyInfo sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
        return (string[])sortingLayersProperty.GetValue(null, new object[0]);
    }

    // Get the unique sorting layer IDs
    public int[] GetSortingLayerUniqueIDs()
    {
        Type internalEditorUtilityType = typeof(InternalEditorUtility);
        PropertyInfo sortingLayerUniqueIDsProperty = internalEditorUtilityType.GetProperty("sortingLayerUniqueIDs", BindingFlags.Static | BindingFlags.NonPublic);
        return (int[])sortingLayerUniqueIDsProperty.GetValue(null, new object[0]);
    }
}