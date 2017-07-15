namespace YamlUserModel
{
    public class Transform:YamlComponentBase
    {
        public UnityEngine.Quaternion m_LocalRotation { get; set; }
        public UnityEngine.Vector3 m_LocalPosition { get; set; }
        public UnityEngine.Vector3 m_LocalScale { get; set; }
        public InFileHold[] m_Children { get; set; }
        public InFileHold m_Father { get; set; }
        public int m_RootOrder { get; set; }
        public UnityEngine.Vector3 m_LocalEulerAnglesHint { get; set; }
    }
}
