using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GameController))]
public class GameControllerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();

        GameController controller = (GameController)target;

        //Add whatever properties you want to see here...
        EditorGUILayout.LabelField("Property:", "" + controller.PlayerDead);
    }
}

    