using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Reflection;
using System;
using UnityEngine.Events;
using Object = UnityEngine.Object;

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
        public static GameObject GenPrefab(string path, GameObject obj)
        {
            FileUtility.InitFileDiractory(path);
            GameObject pfb = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (pfb == null)
            {
                pfb = PrefabUtility.CreatePrefab(path, obj, UnityEditor.ReplacePrefabOptions.ConnectToPrefab);
            }
            else
            {
                pfb = PrefabUtility.ReplacePrefab(obj, pfb, ReplacePrefabOptions.ConnectToPrefab);
            }
            return pfb;
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
        /// <summary>
        /// 将MonoScript上的数据保存到变量记录器
        /// </summary>
        /// <param name="behaiver"></param>
        /// <param name="variables"></param>
        public static void AnalysisVariableFromComponent(Component behaiver, List<Variable> variables)
        {
            var assembleUnity = typeof(Vector2).Assembly;
            variables.Clear();
            var type = behaiver.GetType();
            FieldInfo[] publicFields = type.GetFields(BindingFlags.GetField | BindingFlags.Instance | BindingFlags.Public);
            foreach (var item in publicFields)
            {
                Variable var = new Variable();
                var.name = item.Name;
                var.type = item.FieldType.ToString();
                var.assemble = item.FieldType.Assembly.ToString();
                if (item.FieldType.Assembly == assembleUnity)
                {
                    var.value = JsonUtility.ToJson(item.GetValue(behaiver));
                }
                else
                {
                    var.value = Convert.ToString(item.GetValue(behaiver));
                }
                var.isPrivate = false;
                variables.Add(var);
            }
            FieldInfo[] privateFields = type.GetFields(BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var item in privateFields)
            {
                var attrs = item.GetCustomAttributes(false);
                if (attrs!= null && attrs.Length > 0 && Array.Find(attrs,x=>x is SerializeField) != null)
                {
                    Variable var = new Variable();
                    var.name = item.Name;
                    var.type = item.FieldType.ToString();
                    var.assemble = item.FieldType.Assembly.ToString();
                   
                    var.isPrivate = true;
                    if (item.FieldType.Assembly == assembleUnity)
                    {
                        var.value = JsonUtility.ToJson(item.GetValue(behaiver));
                    }
                    else
                    {
                        var.value = Convert.ToString(item.GetValue(behaiver));
                    }
                    variables.Add(var);
                }
            }
        }

        /// <summary>
        /// 解析保存的数据信息
        /// </summary>
        /// <param name="variables"></param>
        /// <param name="behaiver"></param>
        public static void InistallVariableToBehaiver(List<Variable> variables, Component behaiver)
        {
            var assembleUnity = typeof(Vector2).Assembly;
            var type = behaiver.GetType();
            foreach (var item in variables)
            {
                if (!item.isPrivate)
                {
                    Type dataType = Assembly.Load(item.assemble).GetType(item.type);
                    object data = null;
                    if (item.assemble == assembleUnity.ToString())
                    {
                        data = JsonUtility.FromJson(item.value, dataType);
                    }
                    else
                    {
                        data = Convert.ChangeType(item.value, dataType);
                    }
                    type.InvokeMember(item.name, BindingFlags.SetField | BindingFlags.Instance | BindingFlags.Public, null, behaiver, new object[] { data }, null, null, null);
                }
                else
                {
                    Type dataType = Assembly.Load(item.assemble).GetType(item.type);
                    object data = null;
                    if (item.assemble == assembleUnity.ToString())
                    {
                        data = JsonUtility.FromJson(item.value, dataType);
                    }
                    else
                    {
                        data = Convert.ChangeType(item.value, dataType);
                    }
                    type.InvokeMember(item.name, BindingFlags.SetField | BindingFlags.Instance | BindingFlags.NonPublic, null, behaiver, new object[] { data }, null, null, null);
                }
            }
        }
    }
}
