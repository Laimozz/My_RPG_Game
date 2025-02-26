using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor
{
    private Waypoint waypointTarget => target as Waypoint;

    private void OnSceneGUI()
    {
        if(waypointTarget.Points.Length <= 0) return;
        Handles.color = Color.red;

        for(int i = 0; i < waypointTarget.Points.Length; i++)
        {
            EditorGUI.BeginChangeCheck();

            Vector2 currentPoint = waypointTarget.EntityPosition + waypointTarget.Points[i];

            Vector2 newPosition = Handles.FreeMoveHandle(currentPoint, 0.5f, 
                Vector2.one * 0.5f, Handles.SphereHandleCap);

            GUIStyle text = new GUIStyle();
            text.fontStyle = FontStyle.Bold;
            text.fontSize = 16;
            text.normal.textColor = Color.black;
            Vector2 textPos = new Vector2(0.2f, -0.2f);
            Handles.Label(waypointTarget.EntityPosition + waypointTarget.Points[i] + textPos, $"{i + 1}", text);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Free Move");
                waypointTarget.Points[i] = newPosition - waypointTarget.EntityPosition ;
            }
        }
    }
}
