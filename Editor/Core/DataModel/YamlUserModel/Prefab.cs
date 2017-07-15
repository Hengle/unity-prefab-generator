namespace YamlUserModel
{
    public class Prefab: YamlObjBase
    {
        public long serializedVersion { get; set; }
        public Modification m_Modification { get; set; }
        public InFileHold m_ParentPrefab { get; set; }
        public InFileHold m_RootGameObject { get; set; }
        public long m_IsPrefabParent { get; set; }
    }
}
