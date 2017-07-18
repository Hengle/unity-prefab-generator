using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PrefabGenerate
{
    public class PGWindow : EditorWindow
    {
        private void OnEnable()
        {
            
        }
        private void OnGUI()
        {
            if (GUILayout.Button("创建asset模板"))
            {
                PGUtility.CreateAsset();
            }
        }
    }
}