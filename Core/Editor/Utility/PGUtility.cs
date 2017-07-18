using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PrefabGenerate
{
    public static class PGUtility 
    {
        private const string Menu_PGWindow = "Window/Prefab-Gen";
        [MenuItem(Menu_PGWindow)]
        private static void OpenPGWindow()
        {
            EditorWindow.GetWindow<PGWindow>();
        }
        public static PGAsset CreateAsset()
        {
            var asset = ScriptableObject.CreateInstance<PGAsset>();
            ProjectWindowUtil.CreateAsset(asset, "PGAsset.asset");
            return asset;
        }
    }
}
