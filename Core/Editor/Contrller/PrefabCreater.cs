using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;
using System;

namespace PrefabGenerate
{
    public class PrefabCreater : IPrefabCreater
    {
        public void CreatePrefab(ObjectNode rootNode)
        {
            var name = (rootNode.obj.item == null ? System.Guid.NewGuid().ToString() : rootNode.obj.item.name) +".prefab";
            var obj = CreateObjFromNode(rootNode);
            PGUtility.GenPrefab("Assets/"+ name, obj);
        }

        private GameObject CreateObjFromNode(ObjectNode node)
        {
            GameObject gameObj = null;
            if (node.obj.item != null){
                gameObj = GameObject.Instantiate(node.obj.item);
                gameObj.name = node.obj.item.name;
            }
            else
            {
                gameObj = new GameObject("EmptyNode");
            }
            //添加脚本等
            foreach (var item in node.outputRight.connections)
            {
                if (item.body!= null)
                {
                    var objh = item.body as ObjectNode;
                    if (objh.isRoot)
                    {
                        //判断是否是根节点，防止循环
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
