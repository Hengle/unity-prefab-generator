namespace YamlUserModel
{
   public class Collider : YamlComponentBase
    {
        public InFileHold m_Material { get; set; }
        public int m_IsTrigger { get; set; }
        public int m_Enabled { get; set; }
        public int serializedVersion { get; set; }
        public Vector3 m_Center { get; set; }
    }
}
