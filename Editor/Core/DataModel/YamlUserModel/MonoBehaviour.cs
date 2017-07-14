namespace YamlUserModel
{
    public abstract class MonoBehaviour
    {
        public int m_ObjectHideFlags { get; set; }
        public InFileHold m_PrefabParentObject { get; set; }
        public InFileHold m_PrefabInternal { get; set; }
        public InFileHold m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public int m_EditorHideFlags { get; set; }
        public OutFileHold m_Script { get; set; }
        public string m_Name;
        public string m_EditorClassIdentifier;
    }
}
