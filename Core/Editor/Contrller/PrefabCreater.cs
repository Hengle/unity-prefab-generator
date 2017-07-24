using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;
using System;
using UnityEditor;

namespace PrefabGenerate
{
    public class PrefabCreater : IPrefabCreater
    {
        public string exprotRoot = "Assets/Prefab-Generator/Demo/PrefabGen/";
        public GameObject CreatePrefab(ObjectNode rootNode)
        {
            var name = (rootNode.obj.name == "" ?"Empty": rootNode.obj.name) +".prefab";
            var obj = CreateObjFromNode(rootNode);
            return PGUtility.GenPrefab(exprotRoot + name, obj);
        }

        private GameObject CreateObjFromNode(ObjectNode node)
        {
            GameObject gameObj = null;
            if (node.obj.item != null){
                gameObj = GameObject.Instantiate(node.obj.item);
                gameObj.name = node.obj.name;
            }
            else
            {
                gameObj = new GameObject("EmptyNode");
            }
            //添加脚本
            foreach (var item in node.sHolds)
            {
                MonoScript monoscript = item.monoScript;
                if (monoscript != null)
                {
                    gameObj.AddComponent(monoscript.GetClass());
                }
            }

            foreach (var item in node.outputRight.connections)
            {
                if (item.body!= null)
                {
                    var objh = item.body as ObjectNode;
                    if (objh is ChildRootNode)
                    {
                        //新预制体并记录信息
                        CreatePrefab(objh);
                    }
                    else
                    {
                       var child = CreateObjFromNode(objh);
                        child.transform.SetParent(gameObj.transform);
                    }
                }
            }
            return gameObj;
        }
    }
}
