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
        void CreatePrefab(ObjectNode rootNode);
    }
}