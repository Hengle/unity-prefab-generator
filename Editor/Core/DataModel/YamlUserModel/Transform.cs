namespace YamlUserModel
{
    public class Transform
    {
        public long m_ObjectHideFlags { get; set; }
        public InFileHold m_PrefabParentObject { get; set; }
        public InFileHold m_PrefabInternal { get; set; }
        public InFileHold m_GameObject { get; set; }
        public UnityEngine.Quaternion m_LocalRotation { get; set; }
        public UnityEngine.Vector3 m_LocalPosition { get; set; }
        public UnityEngine.Vector3 m_LocalScale { get; set; }
        public InFileHold[] m_Children { get; set; }
        public InFileHold m_Father { get; set; }
        public int m_RootOrder { get; set; }
        public UnityEngine.Vector3 m_LocalEulerAnglesHint { get; set; }
    }
}
