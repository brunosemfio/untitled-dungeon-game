using UnityEditor;
using UnityEngine;

namespace Customize.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(BodyPart))]
    public class CustomizationEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var customization = (BodyPart) target;

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("<< Prev")) customization.Prev();

            if (GUILayout.Button("Next >>")) customization.Next();

            EditorGUILayout.EndHorizontal();
        }
    }
}