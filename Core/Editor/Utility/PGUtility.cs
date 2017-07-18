using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PrefabGenerate
{
    public static class PGUtility 
    {
        public static string Menu_PGWindow = "Window/Prefab-Gen";

        public static PGAsset CreateAsset()
        {
            var asset = PGAsset.CreateInstance<PGAsset>();
            ProjectWindowUtil.CreateAsset(asset, "PGAsset.asset");
            return asset;
        }
    }
}
