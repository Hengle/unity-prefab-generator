using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YamlUserModel
{
    public abstract class YamlObjBase
    {
        public long anchor;
        public string tag;
        public long m_ObjectHideFlags { get; set; }
        public InFileHold m_PrefabParentObject { get; set; }
        public InFileHold m_PrefabInternal { get; set; }
    }
}
