using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using NodeEditorFramework;
namespace PrefabGenerate
{
    public interface IPrefabCreater
    {
        GameObject CreatePrefab(ObjectNode rootNode);
    }
}