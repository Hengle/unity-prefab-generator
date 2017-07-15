namespace YamlUserModel
{
   public class BoxCollider:YamlComponentBase
    {
        public InFileHold m_Material { get; set; }
        public int m_IsTrigger { get; set; }
        public int m_Enabled { get; set; }
        public int serializedVersion { get; set; }
        public UnityEngine.Vector3 m_Size { get; set; }
        public UnityEngine.Vector3 m_Center { get; set; }
    }
}
