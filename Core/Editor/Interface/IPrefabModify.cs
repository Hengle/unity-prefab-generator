using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;
namespace PrefabGenerate
{
    public interface IPrefabModify
    {
        void ModifyPrefab(ObjectNode node);
    }
}