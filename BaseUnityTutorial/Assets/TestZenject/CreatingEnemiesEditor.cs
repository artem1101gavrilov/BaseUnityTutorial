using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CreatingEnemies))]
public class CreatingEnemiesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var creatingEnemies = (CreatingEnemies)target;
        if(GUILayout.Button("Create Enemy"))
        {
            creatingEnemies.CreateEnemy();
        }
    }
}
