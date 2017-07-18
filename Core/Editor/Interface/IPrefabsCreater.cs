using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
namespace PrefabGenerate
{
    public interface IPrefabCreater
    {
        GameObject CreatePrefab(PGAsset assetObj);
    }
}