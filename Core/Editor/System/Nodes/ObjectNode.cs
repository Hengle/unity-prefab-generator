using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;
using NodeEditorFramework;
using UnityEditor;
using System;

namespace PrefabGenerate
{
    public abstract class ObjectNode : Node
    {
        public override Vector2 MinSize { get { return new Vector2(200, 10); } }
        public override bool AutoLayout { get { return true; } } // IMPORTANT -> Automatically resize to fit list

        [ValueConnectionKnob("Input Left", Direction.Out, "Float", NodeSide.Right, 40)]
        public ValueConnectionKnob outputRight;

        public ObjHold obj = new ObjHold();
        public List<MonoScript> monoScript = new List<MonoScript>();
        public override void NodeGUI()
        {
            EditorGUILayout.LabelField("This node hold transform!");
            DrawObjectHolder();
            //DrawScriptInfo();
        }

        private void DrawObjectHolder()
        {
            using (var hor = new EditorGUILayout.HorizontalScope())
            {
                obj.name = EditorGUILayout.TextField(obj.name);
                obj.item = EditorGUILayout.ObjectField(obj.item, typeof(GameObject), false) as GameObject;
                if (string.IsNullOrEmpty(obj.name) && obj.item != null) obj.name = obj.item.name;
            }
        }

        //private void DrawScriptInfo()
        //{
        //    using (var hor = new EditorGUILayout.HorizontalScope())
        //    {
        //        EditorGUILayout.SelectableLabel("脚本");
        //        monoScript = EditorGUILayout.ObjectField(monoScript, typeof(MonoScript), false) as MonoScript;
        //    }
        //}

    }
}