using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerStatsSO))]
public class PlayerEditor : Editor
{
    private PlayerStatsSO playerStats => target as PlayerStatsSO;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Reset"))
        {
            playerStats.ResetStats();
        }
    }

}
