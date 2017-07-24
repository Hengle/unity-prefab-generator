using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;
using UnityEngine;
using UnityEditor.UI;
using NodeEditorFramework;
using NodeEditorFramework.Standard;

namespace PrefabGenerate
{
    [CustomEditor(typeof(ObjectNode),true)]
    public class ObjectNodeDrawer : NodeInspector
    {
        SerializedProperty monoScriptProp;
        public new void OnEnable()
        {
            base.OnEnable();
            monoScriptProp = serializedObject.FindProperty("monoScript");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            base.OnInspectorGUI();
            EditorGUILayout.PropertyField(monoScriptProp,true);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
