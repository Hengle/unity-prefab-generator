namespace YamlUserModel
{
    public class Modification
    {
        public InFileHold m_TransformParent { get; set; }
        public Modification[] m_Modifications { get; set; }
        public Component[] m_RemovedComponents { get; set; }
    }
}
