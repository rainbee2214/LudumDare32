using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GameController))]
public class GameControllerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GameController controller = (GameController)target;

        //Add whatever properties you want to see here...
        EditorGUILayout.LabelField("ShipType:", " " + controller.ShipType);
        EditorGUILayout.LabelField("ShipColor:", " " + controller.ShipColor);
        EditorGUILayout.LabelField("RaceType:", " " + controller.RaceType);
        EditorGUILayout.LabelField("PlayerName:", " " + controller.PlayerName);
    }
}

    