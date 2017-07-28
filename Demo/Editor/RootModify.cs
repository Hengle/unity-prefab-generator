using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;
using System;
using UnityEditor;

namespace PrefabGenerate
{
    public class RootModify :PrefabModify
    {
        public string stringValue;
        public override void ModifyPrefab(ObjectNode node)
        {
            Debug.Log(stringValue);
           var script = node.obj.instence.GetComponent<RootScriptBehaiver>();
            var childs = new List<GameObject>();
            foreach (var item in node.outputRight.connections)
            {
                var connected = item.body;
                if (connected is ChildRootNode)
                {
                    var instence = (connected as ObjectNode).obj.instence;
                    var prefab = PrefabUtility.GetPrefabParent(instence);
                    childs.Add(prefab as GameObject);
                }
                else if (connected is NormalNode)
                {
                    childs.Add((connected as ObjectNode).obj.instence);
                }
            }
            script.childItem = childs.ToArray();
        }
    }
}
