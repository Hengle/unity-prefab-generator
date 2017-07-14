namespace YamlUserModel
{
    public class Modification
    {
        public InFileHold m_TransformParent { get; set; }
        public Modification[] m_Modifications { get; set; }
        public Components[] m_RemovedComponents { get; set; }
    }
}
