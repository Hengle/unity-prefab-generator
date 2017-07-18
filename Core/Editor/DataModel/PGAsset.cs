using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrefabGenerate
{
    public class PGAsset : ScriptableObject
    {
        [System.Serializable]
        public class ObjHold
        {
            public string type;
            public Object item; 
        }

        public List<ObjHold> item;
    }
}