using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Samples.Helpers;
using YamlDotNet.RepresentationModel;
using System.Text;
using System.IO;
using System;

public class InformationTest
{

    [Test]
    public void PrintPrefabInfo1()
    {
        var prefabPath = "Assets/Prefab-Generator/Editor/Test/Cube.prefab";
        var input = new StreamReader(prefabPath, Encoding.UTF8);
        var yaml = new YamlStream();
        yaml.Load(input);
        Debug.Log("yaml.Documents.Count=" + yaml.Documents.Count);
        foreach (var item in yaml.Documents)
        {
            YamlMappingNode root = item.RootNode as YamlMappingNode;
            foreach (var yitem in root.Children)
            {
                Debug.Log("[Root] " + yitem.Key + "\n" + "[Tag:]" + item.RootNode.Tag + "\n" + "[Anchor:]" + item.RootNode.Anchor + "\n");
                Debug.Log("[value] " + yitem.Value);
            }
        }
    }

    [Test]
    public void PrintPrefabInfo2()
    {
        var prefabPath = "Assets/Prefab-Generator/Editor/Test/Cube.prefab";
        var input = new StreamReader(prefabPath, Encoding.UTF8);
        var deserializer = new DeserializerBuilder().Build();

        var parser = new Parser(input);
        // Consume the stream start event "manually"
        StreamStart start = parser.Expect<StreamStart>();
        if (start != null)
        {
            var ds = parser.Expect<DocumentStart>();
            Debug.Log(ds);

            Debug.Log(parser.Current.GetType());
            var sd = parser.Expect<MappingStart>();
            Debug.Log(sd.ToString());

            Debug.Log(parser.Current.GetType());
            var sr = parser.Expect<YamlDotNet.Core.Events.Scalar>();
            Debug.Log(sr.Value);

            Debug.Log(parser.Current.GetType());
            //sd = parser.Expect<MappingStart>();
            Debug.Log(sd.ToString());

            //Debug.Log(string.Format("{0}.{0}", ds.Version.Version.Major, ds.Version.Version.Minor));
            var prefab = deserializer.Deserialize<YamlUserModel.Prefab>(parser);
            Debug.Log(prefab);

            //var gameobj = deserializer.Deserialize<YamlUserModel.GameObject>(parser);
            //Debug.Log(gameobj);
        }

    }
}
/*%YAML 1.1
%TAG !u! tag:unity3d.com,2011:
--- !u!1001 &100100000
Prefab:
  m_ObjectHideFlags: 1
  serializedVersion: 2
  m_Modification:
    m_TransformParent: {fileID: 0}
    m_Modifications: []
    m_RemovedComponents: []
  m_ParentPrefab: {fileID: 0}
  m_RootGameObject: {fileID: 1698539120262144}
  m_IsPrefabParent: 1
--- !u!1 &1698539120262144
GameObject:
  m_ObjectHideFlags: 0
  m_PrefabParentObject: {fileID: 0}
  m_PrefabInternal: {fileID: 100100000}
  serializedVersion: 5
  m_Component:
  - component: {fileID: 4178400060267496}
  - component: {fileID: 33326593522863438}
  - component: {fileID: 65475646726610044}
  - component: {fileID: 23591448961635200}
  m_Layer: 0
  m_Name: Cube
  m_TagString: Untagged
  m_Icon: {fileID: 0}
  m_NavMeshLayer: 0
  m_StaticEditorFlags: 0
  m_IsActive: 1
--- !u!4 &4178400060267496
Transform:
  m_ObjectHideFlags: 1
  m_PrefabParentObject: {fileID: 0}
  m_PrefabInternal: {fileID: 100100000}
  m_GameObject: {fileID: 1698539120262144}
  m_LocalRotation: {x: 0, y: 0, z: 0, w: 1}
  m_LocalPosition: {x: 0, y: 0, z: 0}
  m_LocalScale: {x: 1, y: 1, z: 1}
  m_Children: []
  m_Father: {fileID: 0}
  m_RootOrder: 0
  m_LocalEulerAnglesHint: {x: 0, y: 0, z: 0}
--- !u!23 &23591448961635200
MeshRenderer:
  m_ObjectHideFlags: 1
  m_PrefabParentObject: {fileID: 0}
  m_PrefabInternal: {fileID: 100100000}
  m_GameObject: {fileID: 1698539120262144}
  m_Enabled: 1
  m_CastShadows: 1
  m_ReceiveShadows: 1
  m_MotionVectors: 1
  m_LightProbeUsage: 1
  m_ReflectionProbeUsage: 1
  m_Materials:
  - {fileID: 10303, guid: 0000000000000000f000000000000000, type: 0}
  m_StaticBatchInfo:
    firstSubMesh: 0
    subMeshCount: 0
  m_StaticBatchRoot: {fileID: 0}
  m_ProbeAnchor: {fileID: 0}
  m_LightProbeVolumeOverride: {fileID: 0}
  m_ScaleInLightmap: 1
  m_PreserveUVs: 1
  m_IgnoreNormalsForChartDetection: 0
  m_ImportantGI: 0
  m_SelectedEditorRenderState: 3
  m_MinimumChartSize: 4
  m_AutoUVMaxDistance: 0.5
  m_AutoUVMaxAngle: 89
  m_LightmapParameters: {fileID: 0}
  m_SortingLayerID: 0
  m_SortingLayer: 0
  m_SortingOrder: 0
--- !u!33 &33326593522863438
MeshFilter:
  m_ObjectHideFlags: 1
  m_PrefabParentObject: {fileID: 0}
  m_PrefabInternal: {fileID: 100100000}
  m_GameObject: {fileID: 1698539120262144}
  m_Mesh: {fileID: 10202, guid: 0000000000000000e000000000000000, type: 0}
--- !u!65 &65475646726610044
BoxCollider:
  m_ObjectHideFlags: 1
  m_PrefabParentObject: {fileID: 0}
  m_PrefabInternal: {fileID: 100100000}
  m_GameObject: {fileID: 1698539120262144}
  m_Material: {fileID: 0}
  m_IsTrigger: 0
  m_Enabled: 1
  serializedVersion: 2
  m_Size: {x: 1, y: 1, z: 1}
  m_Center: {x: 0, y: 0, z: 0}

UnityEngine.Debug:Log(Object)
InformationTest:PrintPrefabInfo() (at Assets/Editor/Test/InformationTest.cs:21)
System.Reflection.MethodBase:Invoke(Object, Object[])
NUnit.Framework.Internal.<>c__DisplayClass9_0:<InvokeMethod>b__0()
UnityEditor.EditorApplication:Internal_CallUpdateFunctions()
*/
