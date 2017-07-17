using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Samples.Helpers;
using YamlDotNet.RepresentationModel;
using System.IO;

public static class YamlFileUtility
{
    #region Names
    public const string anchor = "anchor";
    public const string tag = "tag";
    public const string m_ObjectHideFlags = "m_ObjectHideFlags";
    public const string serializedVersion = "serializedVersion";
    public const string m_Layer = "m_Layer";
    public const string m_Name = "m_Name";
    public const string m_TagString = "m_TagString";
    public const string m_NavMeshLayer = "m_NavMeshLayer";
    public const string m_StaticEditorFlags = "m_StaticEditorFlags";
    public const string m_IsActive = "m_IsActive";
    public const string m_IsTrigger = "m_IsTrigger";
    public const string m_Enabled = "m_Enabled";
    public const string m_Center = "m_Center";
    public const string m_Size = "m_Size";
    public const string m_Mesh = "m_Mesh";
    public const string m_CastShadows = "m_CastShadows";
    public const string m_ReceiveShadows = "m_ReceiveShadows";
    public const string m_MotionVectors = "m_MotionVectors";
    public const string m_LightProbeUsage = "m_LightProbeUsage";
    public const string m_ReflectionProbeUsage = "m_ReflectionProbeUsage";
    public const string m_Materials = "m_Materials";
    public const string m_StaticBatchInfo = "m_StaticBatchInfo";
    public const string m_StaticBatchRoot = "m_StaticBatchRoot";
    public const string m_ProbeAnchor = "m_ProbeAnchor";
    public const string m_LightProbeVolumeOverride = "m_LightProbeVolumeOverride";
    public const string m_ScaleInLightmap = "m_ScaleInLightmap";
    public const string m_PreserveUVs = "m_PreserveUVs";
    public const string m_IgnoreNormalsForChartDetection = "m_IgnoreNormalsForChartDetection";
    public const string m_ImportantGI = "m_ImportantGI";
    public const string m_SelectedEditorRenderState = "m_SelectedEditorRenderState";
    public const string m_MinimumChartSize = "m_MinimumChartSize";
    public const string m_AutoUVMaxDistance = "m_AutoUVMaxDistance";
    public const string m_AutoUVMaxAngle = "m_AutoUVMaxAngle";
    public const string m_LightmapParameters = "m_LightmapParameters";
    public const string m_SortingLayerID = "m_SortingLayerID";
    public const string m_SortingLayer = "m_SortingLayer";
    public const string m_SortingOrder = "m_SortingOrder";
    public const string m_EditorHideFlags = "m_EditorHideFlags";
    public const string m_Script = "m_Script";
    public const string m_Radius = "m_Radius";
    public const string m_LocalRotation = "m_LocalRotation";
    public const string m_LocalPosition = "m_LocalPosition";
    public const string m_LocalScale = "m_LocalScale";
    public const string m_Children = "m_Children";
    public const string m_Father = "m_Father";
    public const string m_RootOrder = "m_RootOrder";
    public const string m_GameObject = "m_GameObject";
    public const string m_PrefabParentObject = "m_PrefabParentObject";
    public const string m_PrefabInternal = "m_PrefabInternal";
    public const string component = "component";
    public const string m_RootGameObject = "m_RootGameObject";
    public const string fileID = "fileID";
    public const string m_TransformParent = "m_TransformParent";
    public const string m_Modifications = "";
    public const string m_RemovedComponents = "m_RemovedComponents";
    public const string guid = "guid";
    public const string type = "type";
    public const string firstSubMesh = "firstSubMesh";
    public const string subMeshCount = "subMeshCount";
    public const string m_Modification = "m_Modification";
    public const string m_ParentPrefab = "m_ParentPrefab";
    public const string m_IsPrefabParent = "m_IsPrefabParent";
    public const string x = "x";
    public const string y = "x";
    public const string z = "x";
    public const string w = "x";

    #endregion

    public static List<YamlDocument> LoadYamlDocuments(string path)
    {
        var input = new StreamReader(path, Encoding.UTF8);
        var yaml = new YamlStream();
        yaml.Load(input);
        return yaml.Documents.ToList();
    }
    public static YamlNode SurchNode(List<YamlDocument> docs, params object[] path)
    {
        if (docs == null || path.Length < 2)
        {
            return null;
        }
        var anchorName = path[0].ToString();
        var doc = docs.Find(x => x.RootNode.Anchor == anchorName);
        if (doc == null)
        {
            return null;
        }
        int id = 1;
        YamlMappingNode rootNode = doc.RootNode as YamlMappingNode;
        foreach (var item in rootNode.Children)
        {
            //var rootName = item.Key;
            var node = item.Value;

            while (id < path.Length)
            {
                if (path[id] is int)
                {
                    node = node[(int)(path[id])];
                }
                else if (path[id] is string)
                {
                    node = node[(string)(path[id])];
                }
                else
                {
                    return null;
                }
                id++;
            }

            return node;
        }
        return null;
    }
    public static void WritePrefabFile(List<YamlDocument> documents,string path)
    {
        var writer = new StreamWriter(File.OpenWrite(path),Encoding.UTF8);
        writer.WriteLine("%YAML 1.1");
        writer.WriteLine("%TAG !u! tag:unity3d.com,2011:");
        var yaml = new YamlStream();
        foreach (var item in documents)
        {
            yaml.Add(item);
        }
       
        yaml.Save(writer);
        writer.Flush();
        writer.Close();
        //此时生成的格式和unity内置的不一样，但是！！！unity会自己生成标准格式
    }
}
