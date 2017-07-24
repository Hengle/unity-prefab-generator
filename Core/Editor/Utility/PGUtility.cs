using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Events;
namespace PrefabGenerate
{
    public static class PGUtility
    {
        public const string Menu_PGWindow = "Window/Prefab-Gen";

        public static void GenPrefabWithBundleName(string path, string assetBundleName, GameObject obj)
        {
            GenPrefab(path, obj);
            SetAssetBundleName(path, assetBundleName);
        }
        public static void SetAssetBundleName(string path,string assetBundleName)
        {
            if (!FileUtility.IsFileExist(path)) return;
            AssetImporter importer = UnityEditor.AssetImporter.GetAtPath(path);
            importer.assetBundleName = assetBundleName;
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        public static void GenPrefab(string path, GameObject obj)
        {
            FileUtility.InitFileDiractory(path);
            GameObject pfb = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (pfb == null)
            {
                PrefabUtility.CreatePrefab(path, obj, UnityEditor.ReplacePrefabOptions.ConnectToPrefab);
            }
            else
            {
                PrefabUtility.ReplacePrefab(obj, pfb, ReplacePrefabOptions.ConnectToPrefab);
            }
        }
        public static Object TryParent(Object instence)
        {
            if (instence == null) return null;
            var parent = PrefabUtility.GetPrefabParent(instence);
            return parent != null ? parent : instence;
        }
        public static bool ImportAnim(GameObject model, ModelImporterAnimationType type)
        {
            bool haveAnim = true;
            ModelImporter modleImporter = (ModelImporter)AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(model));
            modleImporter.animationType = type;
            modleImporter.animationWrapMode = WrapMode.Once;

            if (modleImporter.defaultClipAnimations.Length > 0)
            {
                foreach (var item in modleImporter.defaultClipAnimations)
                {
                    item.wrapMode = WrapMode.Default;
                }
            }

            if (modleImporter.animationType != ModelImporterAnimationType.None)
            {
                if (modleImporter.defaultClipAnimations != null && modleImporter.defaultClipAnimations.Length == 0)
                {
                    modleImporter.animationType = ModelImporterAnimationType.None;
                    haveAnim = false;
                }
            }
            else
            {
                haveAnim = false;
            }
            modleImporter.SaveAndReimport();
            return haveAnim;
        }
    }
}
