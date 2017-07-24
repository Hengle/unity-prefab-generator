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
    [Node(false, "Object/Object Node")]
    public class ObjectNode : Node
    {
        public const string ID = "objectnode";
        public override string GetID { get { return ID; } }
        public override string Title { get { return "GameObject Node"; } }
        public override Vector2 MinSize { get { return new Vector2(200, 10); } }
        public override bool AutoLayout { get { return true; } } // IMPORTANT -> Automatically resize to fit list

        [ValueConnectionKnob("Input Left", Direction.In, "Float", NodeSide.Left, 20)]
        public ValueConnectionKnob inputLeft;
        [ValueConnectionKnob("Input Left", Direction.Out, "Float", NodeSide.Right, 40)]
        public ValueConnectionKnob outputRight;

        public bool isRoot;
        public ObjHold obj = new ObjHold();
        public MonoScript monoScript;
        public override void NodeGUI()
        {
            EditorGUILayout.LabelField("This node hold transform!");
            DrawObjectHolder();
            //DrawScriptInfo();
        }

        private void DrawObjectHolder()
        {
            isRoot = EditorGUILayout.ToggleLeft("根节点",isRoot);
            using (var hor = new EditorGUILayout.HorizontalScope())
            {
                var newObj = EditorGUILayout.ObjectField(obj.item, typeof(GameObject), false);
                if(newObj != null || newObj != obj.item)
                {
                    obj.item = newObj as GameObject;
                }
                obj.type = EditorGUILayout.TextField(obj.type);
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